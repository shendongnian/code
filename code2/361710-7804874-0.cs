    using System;
    class SummaryAttribute : Attribute {
        public string Value {
            get;
            private set;
        }
        public SummaryAttribute(string value) {
            Value = value;    
        }
    }
    [Summary("Blah")]
    class Foo { 
    }
    class Program {
        static void Main(string[] args) {
            var summaryAttributes = typeof(Foo).GetCustomAttributes(typeof(SummaryAttribute), false);
            if (summaryAttributes.Length != 0) {
                SummaryAttribute summary = (SummaryAttribute)summaryAttributes[0];
                Console.WriteLine(summary.Value);
            }
        }
    }
 
