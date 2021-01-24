    using System;
    using System.Linq;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                comboBoxAnimals.Items.Add("dog");
                comboBoxAnimals.Items.Add("cat");
                comboBoxAnimals.Items.Add("mouse");
                comboBoxAnimals.SelectedIndex = 1;
                txtTimes.Text = "1";
            }
            private void button1_Click(object sender, EventArgs e)
            {
                string selectedAnimal = comboBoxAnimals.SelectedItem.ToString();
                int times = int.Parse(txtTimes.Text);
                var message = string.Concat(Enumerable.Repeat(selectedAnimal, times));
                MessageBox.Show(message);
            }
        }
    }
