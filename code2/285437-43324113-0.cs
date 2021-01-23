    [Serializable]
        internal class DemoForSerializable
        {
            internal string Fname = string.Empty;
            internal string Lname = string.Empty;
    
            internal Stream SerializeToMS(DemoForSerializable demo)
            {
                DemoForSerializable objSer = new DemoForSerializable();
                MemoryStream ms = new MemoryStream();
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, objSer);
                return ms;
            }
    
            [OnSerializing]
            private void OnSerializing(StreamingContext context) {
                Fname = "sheo";
                Lname = "Dayal";
            }
            [OnSerialized]
            private void OnSerialized(StreamingContext context)
            {
           // Do some work after serialized object
            }
    
        }
