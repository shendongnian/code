    public class Foo
    {
        private readonly int id;
        private int type;
        private string name;
        public Foo(int id, int type, string name)
        {
            this.id = id;
            this.type = type;
            this.name = name;
        }
        public int Id { get { return this.id; } }
        public int Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (this.type != value)
                {
                    if (value >= 0 && value <= 5) //Validation rule
                    {
                        this.type = value;
                    } 
                }
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                }
            }
        }
    }
