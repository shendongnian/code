    [Serializable]
    public class ClassA
    {
        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            //Set BSerialized = B based on context or some internal boolean
            BSerialized = B;
        }
        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {
            //Clear BSerialized
            BSerialized = null;
        }
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            //Restore B from BSerialized
            B = BSerialized;
            BSerialized = null;
        }
        [NonSerialized]
        private ClassB B;
        private ClassB BSerialized;
    }
    [Serializable]
    public class ClassB { }
