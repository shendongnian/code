     listView1.Items.Clear();
     SetHeaders(li); // If you have more then one ListView in the same form. Otherwise don't use the parameters.
  
     private void SetHeader(ListView li)
     {
       string[] header_names = new string[] {"Id","Name","SurName","Birth Date"};
       	int i = 0;
		foreach (ColumnHeader ch in li.Columns) 
		{
			ch.Text = header_names[i];
			++i;
		}
     }
