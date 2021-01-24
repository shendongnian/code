    public abstract class Building
    {
        string Name { get; set; }
        string Description { get; set; }
    }
    public class Farm : Building
    {
        public int Crop { get; set; }
    }
    public class Mill : Building
    {
        public float Timer { get; set; }
    }
