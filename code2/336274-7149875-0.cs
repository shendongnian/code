    /// <summary>
    /// Displays ":)" if obj is a Foo
    /// </summary>
    public static void CaseType(object obj)
    {
        switch(obj.GetType().Name)
        {
            case "Foo":
               MessageBox.Show(":)");
               break;
                 default:
               MessageBox.Show(":(");
               break;
        }
    }
