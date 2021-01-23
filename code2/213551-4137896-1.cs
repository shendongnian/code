    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static IDictionary<string, Control> controls;
    
            static void Main(string[] args)
            {
                controls = new Dictionary<string, Control>();
                controls.Add("textbox thing", new TextBox());
                controls.Add("checkbox thing", new CheckBox());
    
                foreach (var control in controls)
                {
                    Console.WriteLine(control.Key);
                }
    
                Console.ReadLine();
            }
        }
    }
