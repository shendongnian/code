    using System.Windows.Forms;
    
    class Test
    {
        static void Main()
        {
            Form form = new Form();
            Button button = new Button { Text = "Toggle" };
            button.Click += delegate { form.ShowInTaskbar = !form.ShowInTaskbar; };
            form.Controls.Add(button);
            Application.Run(form);
        }
    }
