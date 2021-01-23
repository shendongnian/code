    foreach(KeyValuePair<string,object> item in ChangeQueue){
       Console.WriteLine(item.Key);// name of property
       Console.WriteLine(item.Value); // value of property
    }
    
    
    public void SetValue(string name, object value){
       PropertyInfo p = this.GetType().GetProperty(name);
       // following convert and raise an exception to preserve type safety
       ChangeQueue[name] = Convert.ChangeType(value,p.PropertyType);
    }
    
    public void ApplyChanges(){
       foreach(KeyValuePair<string,object> item in ChangeQueue){
          PropertyInfo p = this.GetType().GetProperty(item.Key);
          p.SetValue(this, item.Value, null);
       }
    }
