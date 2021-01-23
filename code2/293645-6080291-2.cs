    namespace CrossFormAccess {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
            }
            private void ShowForm2(object sender, EventArgs e) {
                using (Form2 form = new Form2()) {
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK) {
                        comboBox1.Items.Clear();
                        comboBox1.Items.AddRange(form.Items);
                    }
                }
            }
        }
    }
