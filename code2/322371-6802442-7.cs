    public class Project
    {
        XElement self;
        public Project(XElement project)
        {
            self = project;
        }
    
        public TestCycle TestCycle
        {
            get 
            { 
                // If there are more than one TestCycle per project, you may end 
                // up creating something similar to TestCycle.Files (see TestCycle class below)
                XElement testCycle = self.Element("TestCycle");
                if(null == testCycle)
                    self.Add(testCycle = new XElement("TestCycle"));
                return new TestCycle(testCycle);
            }
        }
    
        public string Name
        {
             get { return (string)(self.Attribute("Name") ?? string.Empty); }
             set { self.Set("Name", value, true); } // see Set Extension method below
        }
        public static IEnumerable<Project> Load(string filename)
        {
             return XElement.Load(filename)).Elements("Project").Select(xp => new Project(xp));
        }
    }
    
    public class TestCycle
    {
        XElement self;
        public TestCycle(XElement testCycle)
        {
            self = testCycle;
        }
        private XElement XFiles
        {
            get 
            {
                XElement files = self.Element("Files");
                if(null == files)
                    self.Add(files = new XElement("Files"));
                return files;
            }
        }
    
        public IEnumerable<FileHash> Files
        {
            get 
            {
                return XFiles.Elements("File").Select(xf => new FileHash(xf));
            }
        }
        public int Number
        {
             get { return (int)(self.Attribute("Number") ?? 0); }
             set { self.Set("Number", value, true); } // see Set Extension method below
        }
        public FileHash AddFile(string name, string hashCode)
        {
             FileHash file = Files.FirstOrDefault(xf => xf.Name == name);
             if(null != file)
                 file.self.Remove(); // replacing (but could throw an exception saying already exists instead)
             XElement xFile = new XElement("File");
             self.Add(xFile);
             file = new FileHash(xFile)
             {
                 Name = name,
                 HashCode = hashCode
             };
             return file;
        }
    }
    
    public class FileHash
    {
        internal XElement self;
        public FileHash(XElement fileHash)
        {
            self = fileHash;
        }
    
        public string Name
        {
             get { return (string)(self.Attribute("Name") ?? string.Empty); }
             set { self.Set("Name", value, true); } // see Set Extension method below
        }
    
        public string HashCode
        {                 
             get { return return (string)(self.Attribute("HashCode") ?? string.Empty); }
             set { self.Set("HashCode", value, true); } // see Set Extension method below
        }
    }
                     
