    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace ConsoleApplication1 {
        class Program {
            static void Main(string[] args) {
                Console.WriteLine("Reflecting TestClass");
                foreach (var property in typeof(TestClass).GetProperties()) {
                    foreach (Author author in property.GetCustomAttributes(typeof(Author), true).Cast<Author>()) {
                        Console.WriteLine("\tProperty {0} Has Author Attribute Version:{1}", property.Name, author.version);
                    }
                }
                var temp = new TestClass();
                Console.WriteLine("Reflecting instance of Test class ");
                foreach (var property in temp.GetType().GetProperties()) {
                    foreach (Author author in property.GetCustomAttributes(typeof(Author), true).Cast<Author>()) {
                        Console.WriteLine("\tProperty {0} Has Author Attribute Version:{1}", property.Name, author.version);
                    }
                }
            }
    
        }
    
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
        public class Author : Attribute {
            public Author(string name, int v) {
                this.name = name;
                version = v;
            }
    
            public double version;
            string name;
        }
    
        public class TestClass {
            [Author("Bill Gates", 2)]
            public TextBox TestPropertyTextBox { get; set; }
        }
    
    }
