        private void XmlTest()
        {
            String xml = "<NewDataSet><Test_x0020_Table><name>Customer1</name><address>25 Big St</address><suburb>Sydney NSW</suburb><contact>Fred Nurk</contact><phone>11 1111 1111</phone></Test_x0020_Table></NewDataSet>";
            XDocument doc = XDocument.Parse(xml);
            XElement element = doc.Descendants("Test_x0020_Table").First();
            XElement newElement = new XElement("Customers", element.Descendants());
            MessageBox.Show(newElement.ToString());
        }
