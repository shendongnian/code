    private void fieldsArea_MouseDown(object sender, MouseEventArgs e)
    {
      if (fieldsArea.Items.Count == 0)
                return;
      int index = fieldsArea.IndexFromPoint(e.Location);
      string s = fieldsArea.Items[index].ToString();
    
      if(e.Clicks>1)
      {          
           selectedFieldsArea.Items.Add(s); 
      }
      else
      {
            DragDropEffects dde1 = DoDragDrop(s,
            DragDropEffects.All);
      }
    }
         
