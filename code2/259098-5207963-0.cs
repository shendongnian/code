    public bool Process()
        {
            var importFile = new FileInfo("c:\\foo\myzip.zip");
            var success = true;
            using (var zipStream = new ZipInputStream(importFile.OpenRead()))
            {
                ZipEntry theEntry;
                while ((theEntry = zipStream.GetNextEntry()) != null)
                {
                    var lowerName = theEntry.Name.ToLower();
                    try
                    {
                        if (lowerName.EndsWith(".xml") && !lowerName.StartsWith("__macosx"))
                        {
                            
                            var doc = new XmlDocument();
                            doc.Load(zipStream);
                        }
                    }
                    catch (Exception e)
                    {
                        success = false;
                        Log.Error(string.Format("Error parsing {0} ERROR {1}",lowerName,e.Message));
                    }
                }
            }
            return success;
        }
