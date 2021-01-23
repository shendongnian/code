    public string getDBpath() {
                string path1 = Assembly.GetExecutingAssembly().Location;
                string path2 = "safer.sdf";
                string path3 = Path.Combine(path1, path2);
                return path3;
            }
            public string getXmlPath() {
                string path1 = Assembly.GetExecutingAssembly().Location;
                string path2 =  @"data/fp.xml";
                string path3 = Path.Combine(path1, path2);
                return path3;
            }
            public string getXmlPathTxt() {
                string path1 = Assembly.GetExecutingAssembly().Location;
                string path2 = @"data/xml_data.txt";
                string path3 = Path.Combine(path1, path2);
                return path3;
            }
