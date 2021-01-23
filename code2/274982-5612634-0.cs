    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Using derived way.
            List<Animal> animals = new List<Animal>();
            animals.Add(new Rat("the rat's name"));
            animals.Add(new Elephant("the elephant's name"));
            foreach (Animal a in animals)
            {
                Console.WriteLine(
                    string.Format("Name of animal: {0}"), a.Name));
            }
        }
    }
    public class Animal
    {
        public Animal(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get;
            private set;
        }
    }
    public class Elephant : Animal
    {
        public Elephant(string name)
            :base(name)
        {
        }
        public string AnimalProps
        {
            get;
            set;
        }
    }
    public class Rat :Animal
    {
        public Rat(string name)
            :base(name)
        {
        }
        public string RatProps
        {
            get;
            set;
        }
    }
