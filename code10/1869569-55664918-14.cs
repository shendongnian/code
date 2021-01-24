    [Serializable]
    public class Dialogues
    {
        public Dialogue[] DialogueList;
    }
    
    [Serializable]
    public class Dialogue
    {
        public string Text;
        public string[] Choices;
        public string[] Consequences;
    }
