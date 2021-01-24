     Stringbuilder sb =new StringBuilder();
   
     private void btn1_Click(object sender, RoutedEventArgs e)
        {
            //Suppose that ListBox name is listBox1
    
            for(int i=0;listBox1.Items.Count; i++)
            {  
               sb.Append(listBox1.Items[i].ToString());
            }
        }
