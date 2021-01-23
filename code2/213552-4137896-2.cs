    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace ConsoleApplication1
    {
        class ClassA
        {
            public Control Control { get; set; }
            public string Group { get; set; }
            public string Subgroup { get; set; }
        }
    
        class Program
        {
            static IList<ClassA> controls;
    
            static void Main(string[] args)
            {
                controls = new List<ClassA>();
                controls.Add(new ClassA
                {
                    Control = new TextBox(),
                    Group = "Input",
                    Subgroup = "Text"
                });
    
                controls.Add(new ClassA
                {
                    Control = new CheckBox(),
                    Group = "Input",
                    Subgroup = "Checkbox"
                });
    
                foreach (var control in controls)
                {
                    Console.WriteLine(control.Subgroup);
                }
    
                Console.ReadLine();
            }
        }
    }
