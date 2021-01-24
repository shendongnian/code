    [Serializable]
    public class Dialogues
    {
        public Dialogue[] DialogList;
    }
    
    [Serializable]
    public class Dialogue
    {
        public string Text;
        public string[] Choices;
        public string[] Consequences;
    }
