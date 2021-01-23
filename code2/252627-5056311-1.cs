    using (XmlReader reader = XmlReader.Create(Server.MapPath("feedback.xml")))
    {
        while (reader.Read())
        {
            if (reader.Value == "\n")
            {
                Response.Write("<br />");
            }
            else
            {
                Response.Write(reader.Value);
            }
        }
    }
