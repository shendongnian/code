    using System;
    using System.Media;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace temp
    {
        public partial class Form1 : Form
        {
            private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    
            public Form1()
            {
                InitializeComponent();
    
                var button1 = new Button {Text = "Start"};
                button1.Click += Button1OnClick;
    
                var button2 = new Button {Text = "Abort"};
                button2.Click += Button2OnClick;
    
                var panel = new FlowLayoutPanel();
                panel.Controls.Add(button1);
                panel.Controls.Add(button2);
    
                Controls.Add(panel);
            }
    
            private async void Button1OnClick(object sender, EventArgs e)
            {
                try
                {
                    var token = _cancellationTokenSource.Token;
    
                    await Task.Run(async () =>
                    {
                        for (var i = 0; i < 10; i++)
                        {
                            token.ThrowIfCancellationRequested();
    
                            await Task.Delay(3000, token);
    
                            SystemSounds.Beep.Play();
                        }
                    }, token);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
    
            private void Button2OnClick(object sender, EventArgs e)
            {
                _cancellationTokenSource.Cancel();
            }
        }
    }
