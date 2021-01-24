    using System.IO;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Text.RegularExpressions;
    
    [assembly: TagPrefix("SmartOBJ.Web.UI.WebControls", "SmartOBJ")]
    namespace SmartOBJ.Web.UI.WebControls
    {
        [ToolboxData("<{0}:SampleControl runat=server></{0}:SampleControl>")]
        public class SampleControl : CompositeControl
        {
            #region members
            private Button button1;
            private ClientCallback delRECORD;
            #endregion
    
            protected override void OnPreRender(System.EventArgs e)
            {
                base.OnPreRender(e);
    
                // Register client side script for the callbacks
                string clientScript = GetResource("SmartOBJ.Web.UI.WebControls.Resources.SampleControlClientScript.js");
                clientScript = clientScript.Replace("{button1_callback_reference}", GetCallbackReference(button1Callback));
                clientScript = clientScript.Replace("{delRECORD_callback_reference}", GetCallbackReference(delRECORD));
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "client_script", clientScript, true);
            }
    
            protected override void CreateChildControls()
            {
                // Create buttons
                button1 = new Button
                              {
                                  ID = "Button1",
                                  Text = "Button 1",
                                  Visible = false,
                                  OnClientClick = "button1Clicked(ID_RECORD, '', callbackComplete);return false;"
    
                              };
                Controls.Add(button1);
    
    
                // Create callback controls
                delRECORD = new ClientCallback { ID = "delRECORD" };
                delRECORD.Raise += delRECORD_Raise;
                Controls.Add(delRECORD);
    
    
            }
    
            protected override void RenderContents(HtmlTextWriter writer)
            {
                // Render buttons
                button1.RenderControl(writer);
    
                // Render result div
                writer.AddAttribute(HtmlTextWriterAttribute.Id, "result");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.RenderEndTag();
    
                // Render callback controls
                delRECORD.RenderControl(writer);
            }
    
            /// Handles client callback events for delRECORD.
            /// <param name="eventArgument">
            private string delRECORD_Raise(string eventArgument)
            {
                ToolsDB mytool=new ToolsDB();
                bool verify=false;
                string msg="";
                string msg2 = "";
    
                string[] parameters = Regex.Split(eventArgument, ";"); 
    
                if  (parameters[1] == "E")
                    {
                        msg = "msg1";
                        msg2= " msg2"; 
                        verify=mytool.delRECORD(parameters[0],parameters[1]); // This part execute other code to manage DB and is defined in another class
                    }
    
                if (parameters[1] == "SC")
                {
                    msg = " msg1";
                    msg2 = " msg2";
                    verify = mytool.delRECORD(parameters[0], parameters[1]);
                }
    
    
                if (verify == true) 
                    {return "ALLISOK;" + parameters[0] +";Record with ID " + parameters[0] + msg;}
                else
                    { return "NOTOK;" + parameters[0] + ";Record with ID " + parameters[0] + msg2; }        
            }
    
            private string button1Callback_Raise(string eventArgument)
            {
                return eventArgument.ToString() + "_" + "Button 1 callback processed." ;
            }
    
   
            /// Helper to load embedded resource as a string.
            private static string GetResource(string resourceName)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string result = string.Empty;
                Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
                if (resourceStream != null)
                {
                    using (TextReader textReader = new StreamReader(resourceStream))
                    {
                        result = textReader.ReadToEnd();
                    }
                }
                return result;
            }
    
            private string GetCallbackReference(Control control)
            {
                return Page.ClientScript.GetCallbackEventReference(control, "arg", "callback", "context");
            }
        }
    }
