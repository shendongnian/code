    using System.Reflection;
    
    ...
    
    protected string Write_TextBox(TextBox tb, string text) {
      if (null == tb)
        throw new ArgumentNullException(nameof(tb));
    
      var method =  GetType().GetMethod(
        $"{tb.Name}_TextChanged", 
           BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
    
      if (null == method) {
        tb.Text = text ?? "";
    
        return text;
      }
    
      Delegate dlg = Delegate.CreateDelegate(typeof(EventHandler), this, method);
    
      // tb.TextChanged -= tb.ID + "_TextChanged";
      tb.GetType().GetEvent("TextChanged").RemoveEventHandler(tb, dlg);
    
      try {
        tb.Text = text ?? "";
      }
      finally {
        // tb.TextChanged += tb.ID + "_TextChanged";
        tb.GetType().GetEvent("TextChanged").AddEventHandler(tb, dlg); 
      }    
     
      return text;
    }
