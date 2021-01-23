    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
        public interface ITaggable {}
    
        public struct TagStruct : ITaggable {}
        public class  TagObject : ITaggable {}
    
        public static IEnumerable<T> DoSomething<T>(IEnumerable<T> input) 
            where T: ITaggable
        {
            foreach (var i in input) yield return i;
        }
    
        public static void Main(string[] args)
        {
            var structs = new [] { new TagStruct() };
            var objects = new [] { new TagObject() };
    
            Console.WriteLine(DoSomething(structs).First().GetType());
            Console.WriteLine(DoSomething(objects).First().GetType());               
        }
    }
