    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Windows.Forms;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Assembly prjB = Assembly.LoadFile(@"C:\...\PrjB.exe");
                foreach (Type t in prjB.GetTypes())
                    if (t.IsSubclassOf(typeof(Form)))
                    {
                        Console.WriteLine(t.Name);
                        Form frm = (Form)Activator.CreateInstance(t);
                        frm.ShowDialog();
                    }
                Console.ReadLine();
            }
        }
    }
