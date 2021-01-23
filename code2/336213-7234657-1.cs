    foreach(Property p in Object.Properties)
    {
      switch(p.FormType)
      {
        case FormType.CheckBox:
          PageForm.AddField(new CheckboxFormField(p.Name, p.Value));
          break;
        case FormType.Email:
          PageForm.AddField(new EmailFormField(p.Name, p.Value));
          break;
        case FormType.etc:
          ...
          break;
      }
    }
