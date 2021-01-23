     //1. Create dataset
            var ds = new DataSet("A Dataset");
            var table = ds.Tables.Add("A Table");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Description", typeof(string));
            //2. Serialize as xml
            ds.WriteXml(@"C:\temp\dataset.xml");
            //3. Go look at the xml file's contents.
            //Your xml needs to be translated into this schema. 
            //You will have to write this. (Boring transform work...)
            //Dataset deserialization does not work with arbitrary xml documuents.
            //4. Loading the xml file
            var ds2 = new DataSet();
            ds2.ReadXml(@"C:\temp\dataset.xml");
            //Suggestion. Investigate using LINQ-to-xml. It would be easier to 
            //read the data from your xml schema. You could also load the Dataset tables row by row
            //using this type of approach 
            //1. Load xml data into an XElement.
            var element = XElement.Parse(@"<resultset>
                <datarow>
                    <datacol>Row 1 - Col 1</datacol>
                    <datacol>Row 1 - Col 2</datacol>
                    <datacol>Row 1 - Col 3</datacol>
                </datarow>
            </resultset>
            ");
            //2. Create a dataset
            ds = new DataSet("A Dataset");
            table = ds.Tables.Add("A Table");
            table.Columns.Add("Col1", typeof(string));
            table.Columns.Add("Col2", typeof(string));
            table.Columns.Add("Col3", typeof(string));
            //3. Walk XElements and add rows to tables
            foreach (var row in element.Elements("datarow"))
            {
                var r = table.NewRow();                
                table.Rows.Add(r);
                int i = 0;
                foreach (var columnValue in row.Elements("datacol"))
                {
                    r[i++] = columnValue.Value;
                }
            }         
