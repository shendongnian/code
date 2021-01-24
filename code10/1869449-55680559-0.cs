    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace ConsoleWithForms
    {
        class Program
        {
            static BackgroundWorker worker;
            static MyForm hiddenForm; 
    
            static void Main(string[] args)
            {
                worker = new BackgroundWorker();
                worker.DoWork += DoWork;
                worker.RunWorkerAsync();
    
                Console.WriteLine("Type 'form' or 'quit'...");
                for (var quit = false; !quit;)
                {
                    var line = Console.ReadLine().ToLower();
                    switch (line)
                    {
                        case "quit": quit = true; InvokeCommand("quit"); break;
                        case "form": InvokeCommand("form"); break;
                        default: break;
                    }
                }
            }
    
            private static void DoWork(object sender, DoWorkEventArgs e)
            {
                Application.EnableVisualStyles();
                hiddenForm = new MyForm();
                hiddenForm.Show();
                hiddenForm.Hide();
                Application.Run();
            }
    
            private static void InvokeCommand(string command)
            {
                hiddenForm.BeginInvoke((Action)delegate {
                    hiddenForm.PerformCommand(command);
                });
            }
        }
    
        class MyForm : Form
        {
            public MyForm()
            {
                Text = "MyForm";
                var button = new Button { Text = "New Form", AutoSize = true };
                button.Click += (sender, args) => { new MyForm().Show(); };
                Controls.Add(button);
            }
    
            public void PerformCommand(string command)
            {
                switch(command)
                {
                    case "form": new MyForm().Show(); break;
                    case "quit": Application.ExitThread(); break;
                    default: break;
                }
            }
        }
    }
