    /// <summary>
    /// Displays ":)" if obj is a Foo
    /// </summary>
    public static void CaseType(object obj)
    {
        if (obj is "Foo")
        {
            MessageBox.Show(":)");
        }
        else
        {
            MessageBox.Show(":(");
        }
    }
