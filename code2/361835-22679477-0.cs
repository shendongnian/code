    class Program
    {
        public static void Main()
        {
            StarTrek baseClass = new StarTrek();
            NewGeneration childClass = new NewGeneration();
            baseClass.ShowEnum();
            childClass.ShowEnum();
            Console.ReadLine();
        }
    }
    public class StarTrek
    {
        internal enum Characters
        {
            Kirk, Spock, Sulu, Scott
        }
        public virtual void ShowEnum()
        {
            Type reflectedEnum = typeof(Characters);
            IEnumerable<string> members = reflectedEnum.GetFields()
                                                .ToList()
                                                .Where(item => item.IsSpecialName == false)
                                                .Select(item => item.Name);
            Console.WriteLine(string.Join(", ", members.ToArray()));
        }
    }
    public class NewGeneration : StarTrek
    {
        internal new enum Characters
        {
            Picard, Riker, Worf, Geordi
        }
        public override void ShowEnum()
        {
            Type reflectedEnum = typeof(Characters);
            IEnumerable<string> members = reflectedEnum.GetFields()
                                                .ToList()
                                                .Where(item => item.IsSpecialName == false)
                                                .Select(item => item.Name);
            Console.WriteLine(string.Join(", ", members.ToArray()));
        }
    }
