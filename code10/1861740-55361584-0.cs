        //dataSet is filled with data
        string xml = "";
        foreach (DataRow dr in dataSet.Tables["Items"].Rows)
        {
            XDocument doc = XDocument.Parse("<Detail></Detail>");
            XElement items = doc.Root;
            items.Add(new XElement("Code", dr["Code"]));
            items.Add(new XElement("Qty", dr["Qty"]));
            XElement list = new XElement("SerialNoList");
            items.Add(list);
            foreach (DataRow row in data.Tables["SerialNoList"].Select("Code = '" + dr["Code"] + "'"))
            {
                list.Add(new XElement("SerialNo", row["SerialNo"]));
            }
            xml += doc.ToString();
        }
