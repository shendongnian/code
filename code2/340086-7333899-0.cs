    const string xmlPath = @"XmlFile.xml";
    var ds = new DataSet();
    var fs = new FileStream(xmlPath, FileMode.Open);
            
    try
    {
        ds.ReadXml(fs);
        foreach (DataTable table in ds.Tables)
        {
            Console.WriteLine("Table name: " + table.TableName);
        }
        Console.WriteLine("Test");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    finally
    {
        fs.Close();
    }
