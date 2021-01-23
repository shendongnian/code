    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    namespace SL1Test
    {
        public partial class MainPage : UserControl
        {
            public MainPage()
            {
                InitializeComponent();            
                btnSend.Click += new RoutedEventHandler(btnSend_Click);
                txtConsoleInput.KeyUp += new KeyEventHandler(txtConsoleInput_KeyUp);
                AutoTicker ticker = new AutoTicker("AutoTicker", this);
            }
            void txtConsoleInput_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                {
                    e.Handled = true;
                    ProcessSend();
                }
            }
            void btnSend_Click(object sender, RoutedEventArgs e)
            {
                ProcessSend();
            }
            private void ProcessSend()
            {
                string input = txtConsoleInput.Text;
                ProcessInput(input);
                txtConsoleInput.Text = "";
            }
            public void ProcessInput(string input)
            {
                if (!string.IsNullOrWhiteSpace(input))
                {
                    input = DateTime.Now.ToLocalTime() + "> " + input + "\n";
                    tbMyConsole.Text = tbMyConsole.Text + input;
                    txtConsoleInput.Text = "";
                }
            }
        }
    }
