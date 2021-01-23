    // ====== ====== ====== ====== ====== ====== ====== ====== ====== ====== ======//
    
    <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
        CodeBehind="Scripts.aspx.cs" Inherits="MITool.Scripts" %>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <script type="text/javascript" language="javascript">
            var script = '';
    
            function ShowScriptModal() {
                $('#overlay').css({ width: $(document).width(), height: $(document).height(), 'display': 'block' }).animate({ opacity: 0.85 }, 0, function () { $('#scriptModal').show(); });
            }
    
            function ScriptInputKeypress(e) {
                if (e.keyCode == 13) {
                    ScriptInput();
                }
            }
    
            function ScriptInput() {
                var txtInput = document.getElementById("txtInput");
                var input = txtInput.value;
                var hiddenInput = document.getElementById("hiddenInput");
    
                if (input == '')
                    return;
    
                hiddenInput.value = input;
    
                txtInput.value = '';
            }
    
            function CheckForNewOutput() {
                var outputUpdatePanel = document.getElementById("OutputUpdatePanel");
                var pageScript = outputUpdatePanel.innerHTML;
                if (script != pageScript) {
                    script = pageScript;
                    ScrollToBottom();
                }
                setTimeout("CheckForNewOutput()", 100);
            }
    
            function ScrollToBottom() {
                $('#OutputPanel').scrollTop($('#OutputUpdatePanel').height());
            }
        </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" LoadScriptsBeforeUI="true" />
        <div id="scriptModal">
            <div id="ScriptInputOutput">
                <asp:Panel ID="OutputPanel" runat="server" Width="700" Height="250" ScrollBars="Vertical"
                    Style="margin: 10px auto; border: 1px solid #CCC; padding: 5px;" ClientIDMode="Static">
                    <controls:ScriptOutput ID="ScriptOutputControl" runat="server" />
                </asp:Panel>
                <asp:Panel ID="InputPanel" runat="server" DefaultButton="btnScriptInput" >
                    <asp:TextBox ID="txtInput" runat="server" ClientIDMode="Static" onkeypress="ScriptInputKeypress(event)" />
                    <asp:HiddenField ID="hiddenInput" runat="server" ClientIDMode="Static" />
                    <asp:Button ID="btnScriptInput" runat="server" Text="Script Input" ClientIDMode="Static" OnClick="btnScriptInput_Click" style="display:none" />           
                    <asp:Button ID="btnExit" runat="server" CssClass="floatRight" Text="Exit" OnClick="btnExit_Click" />
                </asp:Panel>
            </div>
        </div>
        <asp:Literal ID="litScript" runat="server" />
        <ul id="breadcrumb">
            <li><a href="/dashboard.aspx">Main page</a> &gt;</li>
            <li class="current">Scripts</li>
        </ul>
        <div class="content">
            <h2>
                <asp:Label ID="lblHeader" runat="server" Text="Scripts" /></h2>
            <div class="clear">
            </div>
            <div class="table-content">
                <asp:Label ID="lblMessage" runat="server" CssClass="redMessage" />
                <asp:Repeater ID="rptScripts" runat="server" OnItemCommand="rptScripts_ItemCommand">
                    <HeaderTemplate>
                        <table class="table" cellpadding="0" cellspacing="0">
                            <tr>
                                <th>
                                    ID
                                </th>
                                <th>
                                    Name
                                </th>
                                <th>
                                    Location
                                </th>
                                <th>
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("ScriptId") %>
                            </td>
                            <td>
                                <%# Eval("Name") %>
                            </td>
                            <td>
                                <%# Eval("Path") %>
                            </td>
                            <td>
                                <asp:LinkButton ID="btnRunScript" runat="server" Text="Run" CommandName="Run" CommandArgument='<%# Eval("ScriptId") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <div>
                </div>
            </div>
        </div>
        <script type="text/javascript" language="javascript">
            CheckForNewOutput();
        </script>
    </asp:Content>
    
    // ====== ====== ====== ====== ====== ====== ====== ====== ====== ====== ======//
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using MITool.Data.ScriptManager;
    using System.Diagnostics;
    using System.IO;
    using System.Web.Security;
    using System.Web.Services;
    using System.Collections.Concurrent;
    using System.Threading;
    
    namespace MITool
    {
        public partial class Scripts : System.Web.UI.Page
        {
            ConcurrentQueue<char> ScriptOutputQueue
            {
                get
                {
                    return (ConcurrentQueue<char>)Session["ScriptOutputQueue"];
                }
                set
                {
                    Session["ScriptOutputQueue"] = value;
                }
            }
            Process CurrentProcess
            {
                get
                {
                    return (Process)Session["CurrentProcess"];
                }
                set
                {
                    Session["CurrentProcess"] = value;
                }
            }
            bool ScriptRunning
            {
                get
                {
                    if (CurrentProcess == null)
                        return false;
                    if (!CurrentProcess.HasExited || !CurrentProcess.StandardOutput.EndOfStream)
                        return true;
                    return false;
                }
            }
            bool OutputProcessing
            {
                get
                {
                    if (ScriptOutputQueue != null && ScriptOutputQueue.Count != 0)
                        return true;
                    return false;
                }
            }
    
            Thread OutputThread;
    
            void Reset()
            {
                ScriptOutputControl.SetTimerEnabled(false);
                ScriptOutputControl.ClearOutputText();
                if (CurrentProcess != null && !CurrentProcess.HasExited)
                    CurrentProcess.Kill();
                if (OutputThread != null && OutputThread.IsAlive)
                    OutputThread.Abort();
                ScriptOutputQueue = new ConcurrentQueue<char>();
    
                litScript.Text = string.Empty;
                txtInput.Text = string.Empty;
            }
    
            void Page_Load(object sender, EventArgs e)
            {
                if (IsPostBack) return;
    
                Reset();
    
                FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                string role = id.Ticket.UserData;
    
                ScriptData data = new ScriptData();
                List<Script> scripts = data.GetScriptsByRole(role);
                rptScripts.DataSource = scripts;
                rptScripts.DataBind();
            }
    
            protected void rptScripts_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
                switch (e.CommandName)
                {
                    case "Run": StartScript(Int32.Parse(e.CommandArgument.ToString()));
                        break;
                }
            }
    
            void StartScript(int id)
            {
                if (ScriptRunning || OutputProcessing)
                    return;
    
                Reset();
    
                ScriptData data = new ScriptData();
                History history = new History()
                {
                    UserName = HttpContext.Current.User.Identity.Name,
                    BatchFileId = id,
                    DateRun = DateTime.Now
                };
                data.CreateHistory(history);            
    
                Script script = data.GetScript(id);
    
                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    FileName = script.Path,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
    
                CurrentProcess = new Process();
                CurrentProcess.StartInfo = psi;
    
                OutputThread = new Thread(Output);
    
                CurrentProcess.Start();
                OutputThread.Start();
                
                ScriptOutputControl.SetTimerEnabled(true);
    
                litScript.Text = "<script type=\"text/javascript\" language=\"javascript\">ShowScriptModal();</script>";
    
                SetFocus("txtInput");
            }
    
            void Output()
            {
                while (ScriptRunning)
                {
                    var x = CurrentProcess.StandardOutput.Read();
                    if (x != -1)
                        ScriptOutputQueue.Enqueue((char)x);
                }
            }
    
            public void btnScriptInput_Click(object sender, EventArgs e)
            {
                string input = hiddenInput.Value.ToString();
    
                ScriptOutputControl.Input(input);
    
                foreach (char x in input.ToArray())
                {
                    if (CurrentProcess != null && !CurrentProcess.HasExited)
                    {
                        CurrentProcess.StandardInput.Write(x);
                    }
                    Thread.Sleep(1);
                }
            }
    
            protected void btnExit_Click(object sender, EventArgs e)
            {
                Reset();
            }
        }
    }
    
    // ====== ====== ====== ====== ====== ====== ====== ====== ====== ====== ======//
    
    <%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScriptOutput.ascx.cs"
        Inherits="MITool.Controls.ScriptOutput" %>
    <asp:Label ID="lblStats" runat="server" Style="color: Red" />
    <br />
    <asp:UpdatePanel ID="OutputUpdatePanel" runat="server" ClientIDMode="Static">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="UpdateTimer" EventName="Tick" />
            <asp:AsyncPostBackTrigger ControlID="btnScriptInput" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:Literal ID="litOutput" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Timer ID="UpdateTimer" Interval="100" runat="server" OnTick="UpdateTimer_Tick" Enabled="false" />
    
    // ====== ====== ====== ====== ====== ====== ====== ====== ====== ====== ======//
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    
    namespace MITool.Controls
    {
        public partial class ScriptOutput : System.Web.UI.UserControl
        {
            string Output
            {
                get
                {
                    if (Session["Output"] != null)
                        return Session["Output"].ToString();
                    return string.Empty;
                }
                set
                {
                    Session["Output"] = value;
                }
            }
    
            ConcurrentQueue<char> ScriptOutputQueue
            {
                get
                {
                    return (ConcurrentQueue<char>)Session["ScriptOutputQueue"];
                }
                set
                {
                    Session["ScriptOutputQueue"] = value;
                }
            }
            Process CurrentProcess
            {
                get
                {
                    return (Process)Session["CurrentProcess"];
                }
                set
                {
                    Session["CurrentProcess"] = value;
                }
            }
            bool ScriptRunning
            {
                get
                {
                    if (CurrentProcess == null)
                        return false;
                    if (!CurrentProcess.HasExited || CurrentProcess.StandardOutput.Peek() != -1)
                        return true;
                    return false;
                }
            }
            bool OutputProcessing
            {
                get
                {
                    if (ScriptOutputQueue != null && ScriptOutputQueue.Count != 0)
                        return true;
                    return false;
                }
            }
    
            public void SetTimerEnabled(bool enabled)
            {
                UpdateTimer.Enabled = enabled;
            }
            public void ClearOutputText()
            {
                Output = string.Empty;
                litOutput.Text = Output;
            }
    
            protected void UpdateTimer_Tick(object sender, EventArgs e)
            {
                ProcessOutput();
    
                if (!ScriptRunning && !OutputProcessing)
                {
                    UpdateTimer.Enabled = false;
    
                    Output += "<br />// SCRIPT END //<br />";
                    litOutput.Text = Output;
                }
            }
    
            public void Input(string s) 
            {
                Output += "<br />// " + s + "<br />";
            }
    
            void ProcessOutput()
            {
                string s = string.Empty;
    
                while (ScriptOutputQueue != null && ScriptOutputQueue.Any())
                {
                    char x;
                    if (ScriptOutputQueue.TryDequeue(out x))
                    {
                        s += x;
                    }
                }
    
                if (s != string.Empty)
                {
                    s = Server.HtmlEncode(s);
                    s = s.Replace("\r\n", "<br />");
    
                    Output += s;
                }
    
                litOutput.Text = Output;
            }
        }
    }
    
    // ====== ====== ====== ====== ====== ====== ====== ====== ====== ====== ======//
