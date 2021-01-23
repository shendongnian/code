    private void button1_Click(object sender, EventArgs e)
        {            
            XmlDocument doc = new XmlDocument();
            using (TextReader tr = File.OpenText(@"c:\test.xml"))
            {
                doc.Load(tr);
            }
            
            doc.DocumentElement.AppendChild(doc.CreateElement("Node"));
            using (TextWriter tw = new StreamWriter(File.OpenWrite(@"c:\test.xml")))
            {
                doc.Save(tw);
            }
        }
