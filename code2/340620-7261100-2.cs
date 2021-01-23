    public Action<Control> GetAddControl(this Control c) 
    {
      var context = SynchronizationContext.Current;
      return (control) =>
      {
         context.Send(_ => c.Controls.Add(control), null);
      };
    }
