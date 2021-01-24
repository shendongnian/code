<!-- -->
        using System;
        using System.Web.UI;
    
        public partial class CheckMonday : Page
        {
           protected void Page_Load(object sender, EventArgs e)
           {
             CheckDate("Invalid Date");
           }
    
            private void CheckDate(string message)
            {
              string dateInput = txtStartDate.Text;
              DateTime dt = Convert.ToDateTime(dateInput);
              DayOfWeek today = dt.DayOfWeek;
    
              if (today != DayOfWeek.Monday)
              {
                 MessageBoxShow(message);
              }
             }
              
             private void MessageBoxShow(string message)
             {
               this.AlertBoxMessage.InnerText = message;
               this.AlertBox.Visible = true;
             }
         }
        
    
