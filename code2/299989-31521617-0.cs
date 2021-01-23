    <XmlData>
        <XmlRow>
            <XmlField1>Data 1</XmlField1>  
            <XmlField2>Data 2</XmlField2>  
            <XmlField3>Data 3</XmlField3>  
            .......
        </XmlRow>
    </XmlData>
    public static class XmlParser
    {
        /// <summary>
        /// Converts XML string to DataTable
        /// </summary>
        /// <param name="Name">DataTable name</param>
        /// <param name="XMLString">XML string</param>
        /// <returns></returns>
        public static DataTable BuildDataTableFromXml(string Name, string XMLString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(XMLString));
            DataTable Dt = new DataTable(Name);
            try
            {
                XmlNode NodoEstructura = doc.FirstChild.FirstChild;
                //  Table structure (columns definition) 
                foreach (XmlNode columna in NodoEstructura.ChildNodes)
                {
                    Dt.Columns.Add(columna.Name, typeof(String));
                }
                XmlNode Filas = doc.FirstChild;
                //  Data Rows 
                foreach (XmlNode Fila in Filas.ChildNodes)
                {
                    List<string> Valores = new List<string>();
                    foreach (XmlNode Columna in Fila.ChildNodes)
                    {
                        Valores.Add(Columna.InnerText);
                    }
                    Dt.Rows.Add(Valores.ToArray());
                }
            } catch(Exception)
            {
            }
            return Dt;
        }
    }
