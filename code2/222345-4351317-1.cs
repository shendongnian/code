    class MemoryWrap : MarshalByRefObject
    {
        public void OpenProcess(int id)
        {
            Memory.OpenProcess(id);
        }
        public int GetOpenedId()
        {
            return Memory.GetOpenedId();
        }
    }
