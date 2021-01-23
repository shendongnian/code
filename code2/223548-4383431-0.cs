    public class SomeControl
    {
         public event EventHandler Click;
    
         public string ArrangeById 
         { 
             set { ViewState["byid"] = value; } 
             get { return ViewState["byid"].ToString(); } 
         }
         public string Value
         {
             set { ViewState["val"] = value; } 
             get { return ViewState["val"].ToString(); }
         }
    
         protected void LnkBtnSort_Clicked(object sender, EventArgs e)
         {
             if( Click != null )
             {
                 this.Click(this, EventArgs.Empty);
             }
         }
    }
