XmlDocument xtr = new XmlDocument();
            string fileName = OFD.FileName;
            FileInfo fileInfo = new FileInfo(fileName);
            string directoryFullPath = fileInfo.DirectoryName;
            fileName = Path.Combine(directoryFullPath, "info.xml");
            xtr.Load(fileName);
            XmlNodeList list = xtr.GetElementsByTagName("SequenceInfo");
            string[] punkty = xtr.InnerText.Split(',');
            List<Point> punkty1 = new List<Point>();
            for (int i = 0; i < punkty.Length; i++)
            {
                punkty1.Add(new Point { X = i, Y = int.Parse(punkty[i])});
            }
