    public partial class Events : System.Web.UI.UserControl
    {
         protected void Item1_Click(object sender, EventArgs e)
        {
    
              var theParam = GetParamValue();
              //code
              Item1Method(theParam);
    
        }
    
        protected void Item2_Click(object sender, EventArgs e)
        {               
               Item2Method();
        }
         private void Item1Method(object param1)
         {
            // Item 1 code goes here...
         }
         private void Item2Method()
         {
              //item 2 code goes here...
              // then call Item1Method
              var param2 = GetParamValue();
              Item1Method(param2);
         }
    }
