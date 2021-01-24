    // using System.Reflection;
    // Below code is meant to be used in a method of the class that holds the fields.
    for (int i = 1; i <= 10; i++)
    {
        if (string.IsNullOrEmpty(this.GetType()
                                     .GetField($"filePath{i}",
                                               BindingFlags.NonPublic | BindingFlags.Instance)?
                                     .GetValue(this))
        {
            errors.Add("File Not Attached");
        }
    }
