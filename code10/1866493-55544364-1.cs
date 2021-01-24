    DataTable dt = new DataTable("simpleTable");
    DataColumn dc = new DataColumn("id", typeof(int)) { AllowDBNull =     false };
    dt.Columns.Add(dc);
    dc = new DataColumn("moneyValue", typeof(string)) { AllowDBNull = true };
    dt.Columns.Add(dc);
    dc = new DataColumn("moneyValueDouble", typeof(double)) { AllowDBNull = true };
    dc.Expression = "IIF(moneyValue = '', null, moneyValue)";
    dt.Columns.Add(dc);
    StringWriter sw = new StringWriter();
    dt.WriteXmlSchema(sw);
    sw.Flush();
    // emit the schema
    Console.WriteLine(sw.ToString());
    DataRow dr = dt.NewRow();
    dr["id"] = 1;
    dr["moneyValue"] = 100;
    dt.Rows.Add(dr);
    // Some xml with two sample rows- the first one will work, the second will not
    string xml = @"<?xml version='1.0' encoding='utf-8'?>
    <DocumentElement>
    <simpleTable>
        <id>3</id>
        <moneyValue/>
       </simpleTable>
    </DocumentElement>";
    TextReader reader = new StringReader(xml);
    dt.ReadXml(reader);
    // not necessary just to have your old datatable
    dt.Columns["moneyValueDouble"].Expression = null;
    dt.Columns.Remove("moneyValue");
    dt.Columns["moneyValueDouble"].ColumnName = "moneyValue";
            
    Console.ReadKey();
 
