    public interface IEnemy
    {
        int Hitpoints { get; set; }
    ...
    }
    public class Orc : IEnemy
    {
        public int Hitpoints { get; set; }
    ...
    }
    public class Ghoul : IEnemy
    {
        public int Hitpoints { get; set; }
    ...
    }
