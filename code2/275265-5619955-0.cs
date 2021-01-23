    class Person
    {
        public string Name { get; set; }
    }
    class Student : Person
    {
        public string StudentId { get; set; }
    }
    class ShopKeeper : Person
    {
        public Shop Shop { get; }
    }
