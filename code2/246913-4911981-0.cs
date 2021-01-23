    foreach(KeyValuePair<string,object> item in ChangeQueue){
       Console.WriteLine(item.Key);// name of property
       Console.WriteLine(item.Value); // value of property
    }
    
    
    public void SetValue(string name, object value){
       ChangeQueue[name] = value;
    }
    
    public void ApplyChanges(){
       foreach(KeyValuePair<string,object> item in ChangeQueue){
          PropertyInfo p = this.GetType().GetProperty(item.Key);
          p.SetValue(this, item.Value, null);
       }
    }
