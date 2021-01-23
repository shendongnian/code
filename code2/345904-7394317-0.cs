    public abstract class Word
    {
        public int WordId { get; set; }
        public string WordText { get; set; }
        //DO NOT map the WordTypeId column
        //as it is used as the Discriminator column
    }
    public class Noun : Word { }
    public class Verb : Word { }
    public class Adjective : Word { }
