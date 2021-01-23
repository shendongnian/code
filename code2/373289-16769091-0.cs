                byte[] buffer = File.ReadAllBytes("test.xml");
                XmlDocument doc = new XmlDocument();
                using (MemoryStream output = new MemoryStream())
                {
                    using (MemoryStream ms = new MemoryStream(buffer ))
                    {
                        doc.Load(ms);
                    }
                    // Make changes to your memory stream here
                    doc.Save(output);//Output stream has the changes.
                }
