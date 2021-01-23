    public enum ProgrammingLanguage
    {
        CSharp,
        VB,
        JAVA
    }
    foreach (ProgrammingLanguage enmLnaguage  in Enum.GetValues(typeof(ProgrammingLanguage)))
    {
         cboProgrammingLanguage.Items.Add(new ListItem(enmLnaguage.ToString(), Convert.ToInt32( enmLnaguage).ToString()));
    }
