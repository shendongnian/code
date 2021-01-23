       public void Serialize(string filename, ObjectToSerialize objectToSerialize)
        {
           Stream stream = File.Open(filename, FileMode.Create);
           BinaryFormatter bFormatter = new BinaryFormatter();
           bFormatter.Serialize(stream, objectToSerialize);
           stream.Close();
        }
     
       public ObjectToSerialize DeSerialize(string filename)
        {
           ObjectToSerialize objectToSerialize;
           Stream stream = File.Open(filename, FileMode.Open);
           BinaryFormatter bFormatter = new BinaryFormatter();
           objectToSerialize = (ObjectToSerialize)bFormatter.Deserialize(stream);
           stream.Close();
           return objectToSerialize;
        }
     
