     XmlTextReader xr = new XmlTextReader("test.xml");
    
                int i=0;
                string[] ss; 
                while (xr.Read())
                {
                    Console.Write(xr.Name);
                    if (xr.Name.ToString() == "name") { ss[i] = xr.ReadString(); i++ };
                }
