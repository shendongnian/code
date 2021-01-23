    public interface ISerializableSet
    {
        bool IsSerializable { get; }
    }
    [Serializable]
    class SerializableClass : ISerializableSet
    {
        [NonSerialized]
        private bool _runTimeCheck = true;
        #region ISerializableSet Members
        public bool IsSerializable
        {
            get { 
                if(!_runTimeCheck)
                    return true;
                if(0 != (this.GetType().Attributes & System.Reflection.TypeAttributes.Serializable))
                    return true;
                return false;
            }
        }
        #endregion
    }
    public static class Bar2
    {
        public static int Foo<T>(T obj) where T : ISerializableSet
        {
            ISerializableSet sc = obj;
            Console.WriteLine("{0}", sc.IsSerializable.ToString());
            return 1;
        }
    }
