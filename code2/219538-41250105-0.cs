    string notes = "";
    
    Type typModelCls = trans.GetType(); //trans is the object name
    foreach (PropertyInfo prop in typModelCls.GetProperties())
    {
        notes = notes + prop.Name + " : " + prop.GetValue(trans, null) + ",";
    }
    notes = notes.Substring(0, notes.Length - 1);
