    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace TagInput
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void TagInputContainer_Click(object sender, EventArgs e)
            {
                TextBox box = new TextBox()
                {
                    Width = 100,
                    Height = 30,
                    Font = new Font("Segoe UI Light", 12),
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.Khaki,
                    Location = new Point(0,0),
                    Dock = DockStyle.Left,
                    Margin = new Padding(2, 0, 0, 0)
                };
    
                TagInputContainer.Controls.Add(box);
            }
        }
    }
