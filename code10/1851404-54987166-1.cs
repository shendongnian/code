         Message.Text = "You chose: <br />";
         
         // Iterate through the Items collection of the ListBox and 
         // display the selected items.
         foreach (ListItem item in ListBox1.Items)
         {
            if(item.Selected)
            {
               Message.Text += item.Text + "<br />";
            }
         }
      }
