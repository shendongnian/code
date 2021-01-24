    public class Template
    {
        public string Name { get; }
        public Template(string name)
        {
            Name = name;
        }
    }
    public class TemplateChild1: Template
    {
        public TemplateChild1()
            : base("Child one")
        { }
    }
