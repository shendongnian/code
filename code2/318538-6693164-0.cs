        /// <summary>
        /// Serializes current EntityBase object into file
        /// </summary>
        // <param name="fileName">full path of outupt xml file</param>
        // <param name="exception">output Exception value if failed</param>
        // <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception) {
            exception = null;
            try {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e) {
                exception = e;
                return false;
            }
        }
        
        public virtual void SaveToFile(string fileName) {
            System.IO.StreamWriter streamWriter = null;
            try {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally {
                if (streamWriter != null) {
                    streamWriter.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Deserializes workflow markup from file into an EntityBase object
        /// </summary>
        // <param name="xml">string workflow markup to deserialize</param>
        // <param name="obj">Output EntityBase object</param>
        // <param name="exception">output Exception value if deserialize failed</param>
        // <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out T obj, out System.Exception exception) {
            exception = null;
            obj = default(T);
            try {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex) {
                exception = ex;
                return false;
            }
        }
        
        public static bool LoadFromFile(string fileName, out T obj) {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }
        
        public static T LoadFromFile(string fileName) {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally {
                if (file != null) {
                    file.Dispose();
                }
                if (sr != null) {
                    sr.Dispose();
                }
            }
        }
