    public class FormContact
    {
       public FormContact(int id) 
       {
         if (id > 0)
         {
            //Load contact for Editing
         }
         else
         {
            //Clear all fields for Adding
            foreach(var ctrl in this.Controls)
            {
                 if (ctrl Is TextBoxBase) ctrl.Text = string.Empty
                 //TODO other controls types... if (ctrl Is ....
            }
         }
       }
    }
