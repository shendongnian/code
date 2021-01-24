    var controlTooltipDictionary = new Dictionary<Control, string>
    {
        [txtUser] = "Select a user",
        [txtPass] = "Enter your password"
    };
        
    foreach (var item in controlTooltipDictionary)
    {
        item.Key.Enter += (s, ea) =>
        {
          tthelp.Show(item.Value,item.Key);
        };
        item.Key.Leave += (s, ea) =>
        {
          tthelp.Hide(this);
        };
     }
