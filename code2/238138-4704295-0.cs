    public class Person : IName
    {
        public string Name {get; set;}
        dynamic IName.Name {
            get { return this.Name; }
            set { this.Name = value as string; }
        }
    } 
