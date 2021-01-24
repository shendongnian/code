    using System;
    using System.Windows.Forms;
    using System.Windows.Input;
    
    namespace MovePlayerDemo
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                timer.Enabled = true;
            }
    
            private void timer_Tick(object sender, EventArgs e)
            {
                if (Keyboard.IsKeyDown(Key.W))
                {
                    picPlayer.Top -= 5;
                }
    
                if (Keyboard.IsKeyDown(Key.S))
                {
                    picPlayer.Top += 5;
                }
            }
        }
    }
