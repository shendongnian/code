    [Serializable]
    public class BinareObjectList<T> : List<T>
    {
        public void LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("File not found", fileName);
            this.Clear();
            try
            {
                IFormatter formatter = new BinaryFormatter();
                // IFormatter formatter = new SoapFormatter();
                Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                List<T> list = (List<T>)formatter.Deserialize(stream);
                foreach (T o in list)
                    this.Add(o);
                stream.Close();
            }
            catch { }
        }
        public void SaveToFile(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
            IFormatter formatter = new BinaryFormatter();
            // IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(fileName, FileMode.CreateNew);
            formatter.Serialize(stream, this);
            stream.Close();
        }
    }
