    interface ISkill
    {
        void Apply();
    }
    
    public abstract class Base
    {
        protected string name { get; set; }
        protected Base(string name)
        {
           this.name = name;
        }
        protected void Show()
        {
            Console.WriteLine("show:"+name);
        }
        // "template" method. 
        public void Apply()
        {
            Show(); 
            ApplyImplementation();
        }
        // derived class must implement that method
        protected abstract void ApplyImplementation();
    }
    
    class Skill1 : Base, ISkill
    {
        public Skill1()
        {
            name = "skill1";
        }
        protected override void ApplyImplementation()
        {
            Console.WriteLine("skill1 apply");
        }
    }
