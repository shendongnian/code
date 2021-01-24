    public class ClassC : MonoBehaviour
    {
        [SerializeField] private float example3;
        [SerializeField] private string example4;
        // etc.
    
        public void SetUp(SerializableClassC values)
        {
            // set all values
            example3 = values.example3;
            example4 = values.example4;
            // etc.
        }
    
        public SerializableClassC GetSerializable()
        {
            var output = new SerializableClassC();
    
            output.example3 = example3;
            output.example4 = example4;
            // etc.
    
            return output;
        }
    }
    
    [Serializable]
    public class SerializableClassC
    {
        public float example3;
        public string example4;
        // etc
    }
