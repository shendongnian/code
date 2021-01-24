    public class ActionsBlockBlock : IntBlock
    {
        IntBlock.type { get; } = "actions";
        IntBlock.blockId { get; set; }
        IntBlock.ElementBlock[] elements { get; set; }
    }
    public interface IntBlock 
    { 
        public string type { get; set; }
        public string blockId { get; set; }
        public ElementBlock[] elements { get; set; }
    }
