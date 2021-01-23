    using System.Windows.Forms;
    
    namespace Answer
    {
        class Program
        {
            static void Main(string[] args)
            {
                Form form = new Form { Text = "Click Me", TopMost = true };
    
                form.MouseClick += (s, e) => {
                    System.Console.WriteLine("MouseClickEvent @ [{0}, {1}] {2}", 
                        e.X.ToString("d"), 
                        e.Y.ToString("d"), 
                        e.Button.ToString()
                    );
                };
    
                form.ShowDialog();
            }
        }
    }
