    foreach (var get_regions in qdb_conn.Regions()) 
    {
        xml_writer.WriteStartElement("Region");
        xml_writer.WriteAttribute("id", XmlConvert.ToString(get_regions.Id));
        xml_writer.WriteAttribute("name", get_regions.Name);
        xml_writer.WriteEndElement();
    }
