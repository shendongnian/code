    using System;
    using Transitions;
    
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Transition t = new Transition(new TransitionType_EaseInEaseOut(2000));
                t.add(this.textBox1, "Top", 200);
                t.run();
            }
        }
    }
