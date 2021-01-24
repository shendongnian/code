    using Microsoft.AnalysisServices.AdomdClient;
    
    try
    {
        var xmlaFileContents = File.ReadAllText("path/to/your/file.xmla");
    
        using (AdomdCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = xmlaFileContents;
            cmd.ExecuteNoQuery();
        }
    }
    catch(Exception)
    {
    }
