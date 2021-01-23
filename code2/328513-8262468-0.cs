    public partial class JQuery
    {
        private Page page;		
        public JQuery(Page pagina) {
            page = pagina;
        }
        public void Alert(string Title, string Message)
        {
            Message = Message.Replace("\n", "<br>");
            string command = String.Format("myCustomDialog('{0}','{1}')", Title, Message);
            ScriptManager.RegisterClientScriptBlock(page, this.GetType(), "", command, true);
        }
    }
