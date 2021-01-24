    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Runtime.Remoting.Messaging;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WindowsFormsApplication1
    {
        public class Part
        {
            public String Name {get; set;}
            public double PartLength {get; set;}
            public double PartMark {get; set;}
            public int Number {get; set;}
    
            public Part(String partName, double length, double mark, int value)
            {
                Name = partName;
                PartLength = length;
                PartMark = mark;
                Number = value;
            }
        }
    
        public class GroupedPart
        {
            public String Name => Parts.First().Name;
            public double PartLength { get; set; }
            public double PartMark { get; set; }
            public int Number { get; set; }
            public List<Part> Parts { get; set; }
    
            public override string ToString()
            {
                return Name;
            }
        }
    }
