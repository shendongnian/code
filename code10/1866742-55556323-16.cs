    interface IHasName
    {
        string Name { get; }
    }
    class Admin : IHasName
    {
        public string Name { get; set; }
    }
    class Student: IHasName
    {
        public string Name { get; set; }
    }
