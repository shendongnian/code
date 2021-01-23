    public ICommand SelectAllCheckedCommand { get; private set; }
    private void OnSelectAllCheckedCommand(object arg )
    {
       if (arg == null || !(arg is NameValueConverterResult)) return;
       NameValueConverterResult prop = arg as NameValueConverterResult;
       //Reflect on the model to find the property we want to update.
       PropertyInfo propInfo = Averagers.FirstOrDefault().GetType().GetProperty(prop.Name);
       if (propInfo == null) return;
       //Set the property on the Model
       foreach (var item in Averagers)
          propInfo.SetValue(item, prop.Value, null);
    } 
