    interface IDisplayable
    {
        string Name {get; set;}
    }
    public class Country : IDisplayable
    {
        public string Name { get; set; }
    }
    public class Person : IDisplayable
    {
        public string Name { get; set; }
    }
    public static void DisplayName(this iDisplayable d)
    {
        return doSomeDisplayLogic(d.Name);
    }
