    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication46
    {
        public partial class Form1 : Form
        {
            enum CheckBoxEnum
            {
                CHECKBOXNONE = 0,
                CHECKBOX1 = 1,
                CHECKBOX2 = 2,
                CHECKBOX3 = 4,
                CHECKBOX4 = 8,
            }
            List<CheckBox> checkboxes;
            CheckBoxEnum boxEnum = CheckBoxEnum.CHECKBOXNONE;
            public Form1()
            {
                InitializeComponent();
                checkboxes = new List<CheckBox>() { checkBox1, checkBox2, checkBox3, checkBox4 };
                foreach (CheckBox box in checkboxes)
                {
                    box.Click += new EventHandler(box_Click);
                }
                switch (boxEnum)
                {
                    case CheckBoxEnum.CHECKBOX1 | CheckBoxEnum.CHECKBOX3 :
                        break;
                }
            }
            private void box_Click(object sender, EventArgs e)
            {
                CheckBox box = sender as CheckBox;
                if (box.Checked)
                {
                    boxEnum |= (CheckBoxEnum)(1 << checkboxes.IndexOf(box));
                }
                else
                {
                    boxEnum &= ~(CheckBoxEnum)(1 << checkboxes.IndexOf(box));
                }
            }
        }
    }
