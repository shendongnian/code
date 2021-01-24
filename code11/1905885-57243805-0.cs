    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
        }
        public class Body
        {
            Dictionary<string, List<BodyPart>> parts;
            public Body(List<Arms> arms_, List<Head> head_) //etc
            {
               Dictionary<string, List<BodyPart>> parts = new Dictionary<string, List<BodyPart>>()
               {
                   {"arms", new List<BodyPart>() {new BodyPart() { name = "Left Arm"}, new BodyPart() { name = "Right Arm"}}},
                   {"head", new List<BodyPart>() {new BodyPart() { name = "Head"}}}
                   //etc
               };
            }
       }
       public class BodyPart
       {
           public string name { get; set;  }
       }
       public class Arms : BodyPart
       {
       }
       public class Head : BodyPart
       {
       }
    }
