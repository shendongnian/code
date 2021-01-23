        On the Button click write this code
          
    
      string sStartupPath = Application.StartupPath;  //the path of ~/bin/debug/
         XmlTextWriter objXmlTextWriter = new XmlTextWriter(sStartupPath + @"\selected.xml", null);
         objXmlTextWriter.Formatting = Formatting.Indented;
         objXmlTextWriter.WriteStartDocument();
         objXmlTextWriter.WriteStartElement("TEST");
         objXmlTextWriter.WriteStartElement("Name"); 
         objXmlTextWriter.WriteStartAttribute("Surname"); //Attribute "Name"
          objXmlTextWriter.WriteString("patel"); //Attribute Value 
          objXmlTextWriter.WriteEndAttribute();
         objXmlTextWriter.WriteString(txtname.Text);
         objXmlTextWriter.WriteEndElement();          //End of Name Element
         objXmlTextWriter.WriteStartElement("Age") ;
         objXmlTextWriter.WriteString(txtage.Text);
         objXmlTextWriter.WriteEndElement();             //End of Age element
         objXmlTextWriter.WriteEndElement();
         objXmlTextWriter.Flush();
         objXmlTextWriter.Close();
        MessageBox.Show("The following file has been successfully created\r\n"
                        + sStartupPath
                        + @"\selected.xml", "XML", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
        //It will create selected.xml file in to your project/bin/debug folder..
        
        The out put of the xml file will be like this
        value of txtName.text=ABC
        value of txtAge.text=XYZ
        
        <?xml version="1.0"?>
        <TEST>
          <Name Surname="patel">ABC</Name>
          <Age>XYZ</Age>
        </TEST>
        
        Hope this will Help.
