    List<string> usernames = new List<string>();
    if (result != null) 
    {
         foreach (SearchResult sr in result)
         {
             usernames.Add(sr.Properties["SAMAccountName"][0]);
         }
    }
    listBox1.DataSource = usernames; //Where listbox is declared in your markup
    listBox1.DataBind();
    
