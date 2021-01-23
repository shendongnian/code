    //Deletes all the previously added parts and adds a new part 
    //containing the string argument which has to be in XML format. 
    public void addCustomXMLPart(string test)
    {
        IEnumerator e = Xlworkbook.CustomXMLParts.GetEnumerator();
        e.Reset();
        CustomXMLPart p;
        //The !p.BuiltIn is because before our customXMLPart there are some
        // Excel BuiltIns of them and if we try to delete them we will get an exception.
        while (e.MoveNext())
        {
            p = (CustomXMLPart)e.Current;
            if (p != null && !p.BuiltIn) 
                p.Delete();
        }
        Xlworkbook.CustomXMLParts.Add(test, Type.Missing);
