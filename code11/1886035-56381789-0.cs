            string input = @"<?xml version="1.0" encoding="UTF-8"?>etc..";
            byte[] byteArray = Encoding.UTF8.GetBytes(input);
            var stream = new MemoryStream(byteArray);
            var doc = new XmlDocument();
            var nodes = doc.SelectNodes(xpath);
            using (var tr = new XmlTextReader(stream))
            {
                tr.Namespaces = false;
                doc.Load(tr);
            }
