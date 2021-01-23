             NameValueCollection map = new NameValueCollection();
                using (DirectoryEntry entry = new DirectoryEntry("IIS://localhost/MimeMap"))
                {
                    PropertyValueCollection properties = entry.Properties["MimeMap"];
                    Type t = properties[0].GetType();
                    foreach (object property in properties)
                    {
                        BindingFlags f = BindingFlags.GetProperty;
                        string ext = t.InvokeMember("Extension", f, null, property, null) as String;
                        string mime = t.InvokeMember("MimeType", f, null, property, null) as String;
                        map.Add(ext, mime);
                    }
                }
