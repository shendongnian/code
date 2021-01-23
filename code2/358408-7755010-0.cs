      internal class SqlDBTransManager : IDBManagerConnection
      {
        private void RunSqlInternal(String pSql, DBManagerParams pDBManagerParams, DBManagerConnection pTransac)
        {
          ////Lots of code, and below is the log
          XmlDocument doc = new XmlDocument();
          XPathNavigator nav = doc.CreateNavigator();
          using (XmlWriter xml = nav.AppendChild())
          {
            xml.WriteStartElement("log");
            xml.WriteAttributeString("Método", "RunSql");
            xml.WriteString(pSql);
            xml.WriteEndElement();
            xml.Flush();
          }
          XmlLogEntry entry = new XmlLogEntry();
          entry.Xml = nav;
          entry.Priority = 1;
          entry.Categories = new String[] { "DB" };
          entry.Severity = TraceEventType.Information;
          Logger.Write(entry);
        
          oCommand.ExecuteNonQuery();
        }
      }
