    public class ClassA : MonoBehaviour, ISerializationCallbackReceiver
    {
        public ClassB _classB;
        public ClassC _classC;
    
        [SerializeField] private SerializableClassB _serializableClassB;
        [SerializeField] private SerializableClassC _serializeableClassC;
    
    
        public void OnBeforeSerialize()
        {
            // before writing to a Json get the information from the MonoBehaviours into the normal classes
            _serializableClassB = _classB.GetSerializable();
            _serializeableClassC = _classC.GetSerializable();
    
        }
    
        public void OnAfterDeserialize()
        {
            // after deserializing write the infromation from the normal classes into the MonoBehaviours
            _classB.SetUp(_serializableClassB);
            _classC.SetUp(_serializeableClassC);
        }
    }
