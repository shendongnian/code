    public abstract class ClientEngine
    {
        public void SaveFile(string fileName);
        {
            byte[] fileStorage = null;
            if (this is MyEntity1)
            {
                MyEntity1 me1 = (MyEntity1)this;
                fileStorage = me1.FileStorage;
            }
            else if (this is MyEntity2)
            {
                MyEntity2 me2 = (MyEntity2)this;
                fileStorage = me2.FileStorage;
            }
            if (fileStorage != null))
                File.WriteAllBytes(fileName, fileStorage);
        }
    }
