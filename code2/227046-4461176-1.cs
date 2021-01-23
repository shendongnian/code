    // <summary>
    /// method for reading an XML file into a DataTable
    /// </summary>
    /// <param name="file">name (and path) of the XML file</param>
    /// <returns></returns>
    public DataTable ReadXML(string file)
    {
        //create the DataTable that will hold the data
        DataTable table = new DataTable("XmlData");
        try
        {
            //open the file using a Stream
            using(Stream stream = new  FileStream(file, FileMode.Open, FileAccess.Read))
            {
                //create the table with the appropriate column names
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Power", typeof(int));
                table.Columns.Add("Location", typeof(string));
    
                //use ReadXml to read the XML stream
                table.ReadXml(stream);
    
                //return the results
                return table;
            }                
        }
        catch (Exception ex)
        {
            return table;
        }
    }
