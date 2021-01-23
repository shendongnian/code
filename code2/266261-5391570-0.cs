     public partial class Events : System.Web.UI.UserControl
     {
          private SomeType variable;
          protected void Item1_Click(object sender, EventArgs e)
         {
               variable = someValue;
               //code
         }
         protected void Item2_Click(object sender, EventArgs e)
         {
               //code + do stuff with variable
         }
     }
