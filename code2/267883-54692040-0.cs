    //Have dictionary setted up
    Dictionary<string, dynamic> m_Dictionary = new Dictionary<string, dynamic>();
    m_xmlDictionary.Add("classA",FOO);
    m_xmlDictionary.Add("classB",BAR);
    m_xmlDictionary.Add("classC",BAR);
    //Have dictionary setted up
    //change the function as below
    public void updatevarx(string class, string varx)
    {
        m_Dictionary[class].A=varx // Replaced switch statement
    }
    //while calling use
    updatevarx("classC","abc!");// This will assign BAR.A with abc!
