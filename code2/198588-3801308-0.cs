    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class Test
    {
        static void Main()
        {
            CheckedListBox clb = new CheckedListBox {
                DisplayMember = "Foo",
                ValueMember = "Bar",
                Items = {
                    new { Foo = "Hello", Bar = 10 },
                    new { Foo = "There", Bar = 20 }
                }
            };
            Form f = new Form
            {
                Controls = { clb }
            };
            Application.Run(f);
        }
    }
