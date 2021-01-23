     private void OnNameChanged(object sender, EventArgs e)
        {
            XmlDocument sampleDoc = new XmlDocument();
             sampleDoc.Load(@"sample.xml");
            sampleDoc.GetElementsByTagName("name")[0].InnerText = textBox1.Text;
            sampleDoc.Save(@"sample.xml");
        }
        private void OnEmailChanged(object sender, EventArgs e)
        {
            XmlDocument sampleDoc = new XmlDocument();
             sampleDoc.Load(@"sample.xml");           
            sampleDoc.GetElementsByTagName("email")[0].InnerText = textBox2.Text;
           sampleDoc.Save(@"sample.xml");
           
        }
        private void OEmpIdChange(object sender, EventArgs e)
        {
            XmlDocument sampleDoc = new XmlDocument();
            sampleDoc.Load(@"sample.xml");
           
            sampleDoc.GetElementsByTagName("EmpID")[0].InnerText = textBox3.Text;
            sampleDoc.Save(@"sample.xml");           
        }
