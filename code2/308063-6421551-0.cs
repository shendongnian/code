    foreach (var control in this.Controls)
    {
       if (control.GetType()== typeof(Button))
       {
                   
           //do stuff with control in form
       }
       else if (control.GetType() == typeof(Panel))
       {
           var panel = control as Panel;
           foreach (var pan in panel.Controls)
           {
               if (pan.GetType() == typeof(Button))
               {
                     
                    //do stuff with control in panel
               }
            }
        }              
    } 
