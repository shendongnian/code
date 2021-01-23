    using System.Reflection;
    using System.ComponentModel;
    using System.Globalization;
    
    ....
    
    Settings settings = new Settings();   // my Settings class with variables to load
    FieldInfo[] fields = settings.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Static);
    ....
    
    foreach (var field in fields)
    {
        if (key.KeyName == field.Name)
        {
            try
            {
                field.SetValue(settings, TypeDescriptor.GetConverter(field.FieldType).ConvertFromString(null, CultureInfo.InvariantCulture, key.Value));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: The value string \"{0}\" isn't parsed!", key.Value);
                //Console.WriteLine(ex.ToString());
            } 
            break;
        }
    }
    
