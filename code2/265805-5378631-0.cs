    Type t = typeof(System.Windows.Forms.PowerStatus);            
    PropertyInfo[] pi = t.GetProperties();            
    for( int i=0; i<pi.Length; i++ )
    {
        Console.WriteLine("Property Name {0}", pi[i].Name);
        Console.WriteLine("Property Value {0}", pi[i].GetValue(SystemInformation.PowerStatus, null));
    }
