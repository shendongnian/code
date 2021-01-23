    public interface IMonster
    {
        String Name { get; }
        Int32 Health { get; set; }
    }
    public class Spider : IMonster
    {
        public Spider()
        {
            _health = 100;
        }
        public string Name
        {
            get { return "Spider"; }
        }
        private int _health;
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
    }
    public class Gollum : IMonster
    {
        public Gollum()
        {
            _health = 250;
        }
        public string Name
        {
            get { return "Gollum"; }
        }
        private int _health;
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<IMonster> monsters = new List<IMonster>()
                                          {
                                              new Gollum(),
                                              new Spider()
                                          };
            IMonster randomMonster = GetRandomMonster(monsters);
            Console.WriteLine(randomMonster.Name + "/" + randomMonster.Health);
        }
        private static IMonster GetRandomMonster(List<IMonster> monsters)
        {
            //Your code for getting a random monster goes here!
            throw new NotImplementedException();
        }
    }
