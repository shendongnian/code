    public Action<Control> GetAddControl(this Control c) 
    {
      var context = SynchronizationContext.Current;
      return (control) =>
      {
         context.Send((Action)(() => c.Controls.Add(control)));
      };
    }
