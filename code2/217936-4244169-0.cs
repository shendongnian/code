     private void button2_Click(object sender, RoutedEventArgs e)     
            {     
                textBox1.Text = treeView1.SelectedItem.ToString();   
                int index = treeView1.Items.IndexOf(treeView1.SelectedItem));   
                 if(index < 0)
                   {
                       index  = Parent.Items.IndexOf(treeView1.SelectedItem));
                   }    
         
                if(index > 0)
                  {
                       Parent.Items.RemoveAt(index);
                  } 
           
            }     
