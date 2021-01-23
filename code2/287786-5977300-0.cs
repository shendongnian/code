     public FlowDocument Load(string path)
        {
            using (StreamReader sReader = System.IO.File.OpenText(path))
            {
                using (Stream s = sReader.BaseStream)
                {
                    return (FlowDocument)XamlReader.Load(s);
                }
            }
        }
