    <%@ Page Language="C#" %>
    <script type="text/c#" runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = new[]
                {
                    new 
                    {
                        SubjectID = "1",
                        SubjectName = "subject name 1" 
                    },
                    new 
                    {
                        SubjectID = "2",
                        SubjectName = "subject name 2" 
                    },
                };
                rptSubject.DataSource = data;
                rptSubject.DataBind();
            }
        }
    
        protected void RptSubject_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                // some code
            }
    
            if (e.CommandName.Equals("EditCategory"))
            {
                // some code
            }
        }    
    </script>
    <!DOCTYPE html>
    <html>
    <head>
        <title></title>
    </head>
    <body>
        <form id="Form1" runat="server">
            <asp:Repeater ID="rptSubject" runat="server" OnItemCommand="RptSubject_OnItemCommand">
                <ItemTemplate>
                    <div>
                        <asp:CheckBox id="chkAll" runat="server"/>
                        <%#Eval("SubjectName") %>
                        <asp:LinkButton ID="imgbtnDelete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("SubjectID") %>' Text="Delete" />
                        <asp:LinkButton ID="lnkEditCategory" runat="server" CommandName="EditCategory" CommandArgument='<%#Eval("SubjectID") %>' Text="Edit" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </form>
    </body>
    </html>
