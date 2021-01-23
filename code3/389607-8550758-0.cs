    using System;
    using System.Windows.Forms;
    using System.Threading;
    using System.Threading.Tasks; // For the fix below
    
    class Program
    {
        static void Main()
        {
            Button button = new Button { Text = "Click me" };
            button.Click += HandleClick;
            Form form = new Form { Controls = { button } };
            Application.Run(form);
        }
        static void HandleClick(object sender, EventArgs e)
        {
            Console.WriteLine("In click handler");
            Button button = (Button) sender;
            button.Enabled = false;
            Thread.Sleep(10000);
            button.Enabled = true;        
            Console.WriteLine("Finishing click handler");
        }
    }
