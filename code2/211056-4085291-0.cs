    using (//file stream)
    {
         using(XmlWriter mywriter = new XmlWriter.Create(@"C:\Auditlog.xml")) {
           // write start element1
           // write start element2
    
                         while (//not end of file)
                        {
                        switch (entrytype)
                        {
                            Case 1:
                               // create elements
                            Case 2:
                               // create elements
                            so on ....
                        }
                        }
    
           // write end element2
           // write endelement1
           mywriter.Close();
        }
    }
