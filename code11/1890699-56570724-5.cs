    public class ClassA : MonoBehaviour, ISerializationCallbackReceiver
    {
        public ClassB _classB;
        public ClassC _classC;
    
        [SerializeField] private SerializableClassB _serializableClassB;
        [SerializeField] private SerializableClassC _serializeableClassC;
    
    
        public void OnBeforeSerialize()
        {
            // before writing to a Json get the information from the MonoBehaviours into the normal classes
            if(_classB) _serializableClassB = _classB.GetSerializable();
            if(_classC) _serializeableClassC = _classC.GetSerializable();
    
        }
    
        public void OnAfterDeserialize()
        {
            // after deserializing write the infromation from the normal classes into the MonoBehaviours
            if(_classB) _classB.SetUp(_serializableClassB);
            if(_classC) _classC.SetUp(_serializeableClassC);
        }
    }
