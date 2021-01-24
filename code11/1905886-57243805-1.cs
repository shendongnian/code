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
                List<BodyPart> arms = new List<BodyPart>() { new BodyPart() { name = "Left Arm" }, new BodyPart() { name = "Right Arm" } };
                List<BodyPart> head = new List<BodyPart>() { new BodyPart() { name = "Head" } };
                new Body(arms, head);
            }
        }
        public class Body
        {
            Dictionary<string, List<BodyPart>> parts = new Dictionary<string, List<BodyPart>>();
            public Body(List<BodyPart> arms_, List<BodyPart> head_) //etc
            {
                parts.Add("arms", arms_);
                parts.Add("head", head_);
            }
        }
        public class BodyPart
        {
            public string name { get; set; }
        }
    }
