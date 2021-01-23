		public partial class WebForm1 : System.Web.UI.Page
		{
         public string CodeBehindVarPublic { get; set; }
		  protected void Page_Load(object sender, EventArgs e)
			{
              CodeBehindVarPublic ="xyz";
           //you should call the next line  in case of using <%#CodeBehindVarPublic %>
             
              DataBind();
			}
}			
