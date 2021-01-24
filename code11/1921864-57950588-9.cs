    [Serializable]
    public class TestDict : SerializableDictionary<string, SceneReference> { }
    public class Example : MonoBehaviour
    {
        public SceneReference NormalReference;
    
        public TestDict DictExample = new TestDict();
    }
    
