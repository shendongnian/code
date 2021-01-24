    using System;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Foo.FooEngine fooEngine = new Foo.FooEngine();
                //TODO: NO LONGER POSSIBLE fooEngine.list.Add(new Foo.Character(0));
                fooEngine.list.Add(new Bar.Character(0, "Test1"));
                fooEngine.list.Add(new Example.Character(0, "Test2"));
                Bar.Character character = (Bar.Character)fooEngine.list[0];
                Example.Character character2 = (Example.Character)fooEngine.list[1];
    
            }
        }
    }
    
    namespace Foo
    {
        using System.Collections.Generic;
    
        public abstract class Character
        {
            public int ID;
        }
    
    
        public class FooEngine
        {
            public List<Foo.Character> list = new List<Foo.Character>();
        }
    }
    
    namespace Bar
    {
    
        public class Character : Foo.Character
        {
            public string name;
            public Character(int ID, string name)
            {
                base.ID = ID;
                this.name = name;
            }
        }
    
    }
    
    namespace Example
    {
    
        public class Character : Foo.Character
        {
            public string name;
            public Character(int ID, string name)
            {
                base.ID = ID;
                this.name = name;
            }
        }
    
    }
