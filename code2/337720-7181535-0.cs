    string connStr = "server=.;database=AdventureWorksLT;integrated security=true;";
    string currentPath=System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    using (CustomDataContext context = new CustomDataContext(connStr, XmlMappingSource.FromUrl(currentPath+"\\CustomerMapping.xml")))
    {
    }
