        public void Savefile (string path)
        {
            System.IO.FileStream FS = new 
            System.IO.FileStream("C:\\Users\\blablablayouknow", System.IO.FileMode.Create);
            BinaryFormatter BF = new BinaryFormatter();
            BF.Serialize(FS, NameofList);
            FS.Dispose();
        }
        public NameofList Loadfile (string path)
        {
            Einträge ET = new Einträge();
            System.IO.FileStream FS = new 
            System.IO.FileStream("C:\\Users\\blablablayouknowagain",
            System.IO.FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();
            BF.Deserialize(FS);
            return ET;
        }
        public BindingList<NameofClass> NameofList= new BindingList<NameofClass>();
        [Serializable]
        public class Einträge // Objekt Listeneinträge
        {
             public string Name { get; set; }
             public string Telefonnummer { get; set; }
        }
