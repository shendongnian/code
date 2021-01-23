    public partial class _Default : System.Web.UI.Page
    {
        public string message1 = null;
        public string message2 = null; 
        public string message3 = null;
    
        public void setVars()
        {
            for (int i = 1; i <=3; i++)
             {
                 this.GetType().GetField("message" + i.ToString()).SetValue(this, "blabla" + i.ToString());
             }
        }
    
    
    
    }
