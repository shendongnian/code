    Test obj = new Test();
    //loop through the private fields of our class
    foreach (var fld in obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
    {
        if (string.IsNullOrEmpty(fld.GetValue(obj) as string))
        {
            errors.Add("File Not Attached in variable: " + field.Name);
        }
    }
