    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static IList<Control> controls;
    
            static void Main(string[] args)
            {
                controls = new List<Control>();
                controls.Add(new TextBox());
                controls.Add(new CheckBox());
    
                foreach (var control in controls)
                {
                    Console.WriteLine(control.GetType());
                }
    
                Console.ReadLine();
            }
        }
    }
