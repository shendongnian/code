    public class ConversationTrigger : MonoBehaviour
    {
        public List<Conversation> conversations;
    
        public void SaveConversations() { }
    
        public void LoadConversations() { }
    }
    
    [Serializable]
    public class Conversation
    {
        public string Name;
        public bool Foldout;
        public List<Dialogue> Dialogues;
    }
    
    [Serializable]
    public class Dialogue
    {
        public string Name;
        public bool Foldout;
        public List<string> Sentences;
    }
    
