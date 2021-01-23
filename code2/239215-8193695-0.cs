    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace FieldClassTest
    {
        class Field : FlowLayoutPanel
        {
            public Label label;
            public TextBox text_box;
    
            public Field(string label_text)
                : base()
            {
                AutoSize = true;
    
                label = new Label();
                label.Text = label_text;
                label.AutoSize = true;
                label.Anchor = AnchorStyles.Left;
                label.TextAlign = ContentAlignment.MiddleLeft;
    
                Controls.Add(label);
    
                text_box = new TextBox();
    
                Controls.Add(text_box);
            }
        }
    
        static class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                var form = new Form();
                
                var panel = new FlowLayoutPanel();
                panel.FlowDirection = FlowDirection.TopDown;
                panel.Dock = DockStyle.Fill;
    
                var first_name = new Field("First Name");
                panel.Controls.Add(first_name);
    
                var last_name = new Field("Last Name");
                panel.Controls.Add(last_name);
    
                form.Controls.Add(panel);
    
                Application.Run(form);
            }
        }
    }
