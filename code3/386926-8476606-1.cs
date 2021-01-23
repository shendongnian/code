    bool found = host.Hostname.ToLower().Contains(searchBox.Text.ToLower());             
    if (!found)
    {
      found = host.IP.ToString().Contains(searchBox.Text.ToLower());
      if (!found)
      {
        found = host.Username.ToString().Contains(searchBox.Text.ToLower()); 
      }
    }
