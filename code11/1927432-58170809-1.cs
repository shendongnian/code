    public partial class EntityClass
    {
        public int MyProperty { get; set; }
        public string String { get; set; }
        public bool Boolean { get; set; }
    }
Then in the same project you define partial class with the same name. Remember to keep exactly the same namespace here as you have for original auto generated model!
    public partial class EntityClass : IEntityClass
    {
        public int AnotherOne { get; set; }
    }
And in your interface project you could add something like this
    public interface IEntityClass
    {
        int MyProperty { get; set; }
        string String { get; set; }
        bool Boolean { get; set; }
        int AnotherOne { get; set; }
    }
Remember that this is very cumbersome approach because you have to remember to update your interface whenever you change your data model. Other way around that is commonly used is defining DTOs (Data Transfer Object).
[Here](https://stackoverflow.com/questions/2850371/asp-net-layered-app-share-entity-data-model-amongst-layers?rq=1) someone asked similar question. Please read this.
