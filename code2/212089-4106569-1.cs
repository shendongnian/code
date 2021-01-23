    protected override bool ProcessKeyPreview(ref Message m)
    {
      var keyCode = (Keys)Enum.ToObject(typeof (Keys), m.WParam);
      //Insert some logic 
      return base.ProcessKeyPreview(ref m);
    }
