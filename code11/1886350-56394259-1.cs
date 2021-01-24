csharp
using MongoDB.Entities;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class Soul : Entity
        {
            public Many<Person> Incarnations { get; set; }
            public One<Person> CurrentIncarnation { get; set; }
            public Soul() => this.InitOneToMany(() => Incarnations);
        }
        public class Person : Entity
        {
            public string Name { get; set; }
            public One<Soul> Soul { get; set; }
            public One<Person> PreviousLife { get; set; }
            public Many<Person> Friends { get; set; }
            public bool IsDead { get; set; } = false;
            public Person() => this.InitOneToMany(() => Friends);
        }
        static void Main(string[] args)
        {
            new DB("test");
            //big bang
            var god = new Soul();
            god.Save();
            //first man is born
            var adam = new Person
            {
                Name = "Adam",
                Soul = god.ToReference()
            };
            adam.Save();
            god.Incarnations.Add(adam);
            god.CurrentIncarnation = adam.ToReference();
            //first woman is born (without a soul ;p)
            var eve = new Person
            {
                Name = "Eve",
            };
            eve.Save();
            //adam and eve become friends under an apple tree
            adam.Friends.Add(eve);
            eve.Friends.Add(adam);
            //adam dies and comes back as sally
            adam.IsDead = true; adam.Save();
            var sally = new Person
            {
                Name = "Sally",
                Soul = god.ToReference(),
                PreviousLife = adam.ToReference()
            };
            sally.Save();
            god.CurrentIncarnation = sally.ToReference();
            god.Incarnations.Add(sally);
            //sally and eve feel a deep connection
            sally.Friends.Add(eve);
            //sally feels stuck in a mans body, so she goes back to being adam
            sally.IsDead = true;
            sally.Save();
            god.CurrentIncarnation = adam.ToReference();
            god.Save();
            adam.IsDead = false;
            adam.PreviousLife = sally.ToReference();
            adam.Save();
            //invite sally's friends to the funeral
            var guestlist = DB.Find<Person>().One(sally.ID)
                                             .Friends.Collection()
                                             .ToList();
        }
    }
}
the library stores relationships by using special join collections which are automatically indexed which makes queries extremely fast.
my personal rule of thumb is to not embed an object inside another if there's gonna be more than a handful of them in there. but it all depends on how your app queries the data, what data is needed by your apps views. with MongoDB.Entities you have the freedom to do both quite easily.
