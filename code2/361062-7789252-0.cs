    using System.Windows.Forms;
    
    namespace Answer
    {
        class Program
        {
            static void Main(string[] args)
            {
                Form form = new Form { Text = "Click Me", TopMost = true };
    
                form.Click += (s, e) => {
                    System.Console.WriteLine("MouseClickEvent @ [{0}, {1}] {2}", e.X, e.Y, e.Button.ToString());
                };
    
                form.ShowDialog();
            }
        }
    }
