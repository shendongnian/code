       using System.Linq; 
       ...
       private void txt_Username_TextChanged(object sender, EventArgs e)
       {
         bool find = lb_Form1_ListUsers
           .Items
           .Cast<String>() //TODO: put the right type here if required
           .Any(item => item == txt_Username.Text);
         lbl_Form1_UniqueError.Visible = find;  
       }
