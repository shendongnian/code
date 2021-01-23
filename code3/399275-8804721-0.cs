    using System.IO;
    using System.Xml.Serialization;
    [Serializable]
        public class Job
        {
            public Job() { }
    
            public int ID { get; set; }
            public int CompanyID { get; set; }
            public string Description { get; set; }
            public int HoursPerWeek { get; set; }
            public int JobStatus { get; set; }
            public int JobType { get; set; }
            public string Location { get; set; }
            public string Title { get; set; }
    
            public void SerializeToXML(string path) 
            {
                //creates a file
                FileStream fs = new FileStream(path, FileMode.Create);
    
                //now we create the serializer
                XmlSerializer xs = new XmlSerializer(typeof(Job));
                //serialize it to the file
                xs.Serialize(fs, this);
                //close the file
                fs.Close();
            }
            public static Job DeserializeToJob(string path) { 
                //open file
                FileStream fs = new FileStream(path, FileMode.Open);
    
                //create deserializer
                XmlSerializer xs = new XmlSerializer(typeof(Job));
    
                //Deserialize
                Job job = (Job)xs.Deserialize(fs);
                //close the file
                fs.Close();
                //return the deserialized job
                return job;
            }
        }
