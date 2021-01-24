    public class Dog : Animal
    {
         string name = null;
         public new string Name { get { return name; } set { name = value; base.Name = name; } } }
    }
