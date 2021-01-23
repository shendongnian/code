    private void WriteXmlToFile(DataSet thisDataSet)
    {
       if (thisDataSet == null) 
       {
          return;
       }
       // Create a file name to write to.
       string filename = "myXmlDoc.xml";
       // Create the FileStream to write with.
       System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
       // Create an XmlTextWriter with the fileStream.
       System.Xml.XmlTextWriter myXmlWriter = 
       new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
       // Write to the file with the WriteXml method.
       thisDataSet.WriteXml(myXmlWriter);   
       myXmlWriter.Close();
    }
