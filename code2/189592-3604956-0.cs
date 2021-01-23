            XDocument doc = XDocument.Load("yourXml.xml");
            var result =
            (from videoInfo in doc.Descendants("videoinfo")
            let quality = videoInfo.Attribute("quality")
            let name = videoInfo.Attribute("name")
            where (quality != null && quality.Value == "1")
                    && (name != null && name.Value == "DSL 2000")
            select new 
                {
                    Title = videoInfo.Element("title"),
                    FileName = videoInfo.Element("filename")
                }
            ).First();
            string title = result.Title.Value;
            string fileName = result.FileName.Value;
