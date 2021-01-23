    <asp:DataList RepeatLayout="Table" RepeatColumns="2" RepeatDirection="Horizontal" runat="server" ID="dl">
	            <ItemTemplate>		        
                    <uc1:UCGroup ID="UCGroup1" runat="server" Title=<%# DataBinder.Eval(Container.DataItem, "RecipientGroup.Name") %> />
                        <div class="template_over"> 
                            <a href="/ScheduleCampaign/<%# DataBinder.Eval(Container.DataItem, "RecipientGroup.Name") %>">
                               
                          <%# DataBinder.Eval(Container.DataItem, "Email") %>
                         
                        </a>
                        </div>
                  </ItemTemplate>	            
                </asp:DataList>
--------------------------------
    public partial class ChooseGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dl.DataSource = GroupsHndlr.GetExtendedRecipients(MySession.Current.ClientId);
            dl.DataBind();
        }
    }
