    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Xml.Serialization;
    
    
    namespace StackoverflowXxmlSerialize
    {
    
        public enum Status { Pending, Active, Completed, Cancelled }
    
        [System.Xml.Serialization.XmlInclude(typeof(UserStory))]
        [System.Xml.Serialization.XmlInclude(typeof(Task))]    
        public abstract class Entity : INotifyPropertyChanged 
        {
            public event PropertyChangedEventHandler PropertyChanged;
        }
    
        
        public class UserStory : Entity
        {
            public uint StoryID { get; set; }
            public Status Status { get; set; }
            public ObservableCollection<Task> Tasks { get; set; }
        }
    
        public class Task : Entity 
        {
            public uint TaskID { get; set; }
        }
    
        class Util
        {
            public static void SerializeObjectToXML<T>(T item, string FilePath)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                using (StreamWriter wr = new StreamWriter(FilePath))
                {
                    xs.Serialize(wr, item);
                }
            }
        }
    
    
    
        public class TestSerialize
        {
            static ObservableCollection<Entity> UserStories { get; set; }
    
            public static void RunTest()
            {
                UserStories = new ObservableCollection<Entity> { 
                    new UserStory  {
                    StoryID = 127,
                    Status = Status.Active,
                    Tasks = new ObservableCollection<Task>{new Task { TaskID = 11 }, new Task { TaskID = 12 }}
                    },
    
                    new UserStory  {
                    StoryID = 128,
                    Status = Status.Cancelled,
                    Tasks = new ObservableCollection<Task>{new Task { TaskID = 13 }, new Task { TaskID = 14 }}
                    },
    
                    new UserStory  {
                    StoryID = 129,
                    Status = Status.Completed,
                    Tasks = new ObservableCollection<Task>{new Task { TaskID = 9 }, new Task { TaskID = 10 }}
                    },
                };
    
    
                ObservableCollection<ObservableCollection<Entity>> Document
                    = new ObservableCollection<ObservableCollection<Entity>>();
    
                Document.Add(UserStories);
                Util.SerializeObjectToXML<ObservableCollection<ObservableCollection<Entity>>>(Document, @"d:\tmp\junk.txt");
    
            }
        }
    
    }
