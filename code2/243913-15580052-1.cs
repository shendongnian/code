    public void FillMeUp(Dictionary<string, string> inputValues){
        PropertyInfo[] classProperties  = this.GetType().GetProperties();
        foreach (PropertyInfo outputClassProperyInfo in classProperties) {
            // Spin through object, getting data from Row
            String propName = outputClassProperyInfo.Name;
            if (inputValues.ContainsKey(propName)) {
                Type propType = outputClassProperyInfo.PropertyType;
                if (propType == typeof(Int32)) {
                    string inputAsString = inputValues[propName];
                    outputClassProperyInfo.SetValue(this, Convert.ToInt32(inputAsString), null);
                } else if (propType == typeof(Int64)) {
                    string inputAsString = inputValues[propName];
                    outputClassProperyInfo.SetValue(this, Convert.ToInt64(inputAsString), null);
                } else if (propType == typeof(string)) {
                    string inputAsString = inputValues[propName];
                    outputClassProperyInfo.SetValue(this, inputAsString, null);
                } else { // Unhandled cases go here, throw exception or something.
                    Console.WriteLine("Kaboooooooom!");
                }
            }
        }        
    }
