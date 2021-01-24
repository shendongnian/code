    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            public void AddHotKey(Action function, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
            {
                KeyDown += delegate (object sender, KeyEventArgs e) { if (IsHotkey(e, key, ctrl, shift, alt)) { function(); } };
            }
    
            public bool IsHotkey(KeyEventArgs eventData, Keys key, bool ctrl = false, bool shift = false, bool alt = false) => 
                                 eventData.KeyCode == key && eventData.Control == ctrl && eventData.Shift == shift && eventData.Alt == alt;
    
            public Form1() => InitializeComponent();
    
            private void Form1_Load(object sender, EventArgs e)
            {
                KeyPreview = true;
    
                String[] names = Enum.GetNames(typeof(Keys));
    
                foreach (string key in names) { comboBox1.Items.Add(key); }
    
                comboBox1.SelectedItem = comboBox1.Items[0];
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                AddHotKey(() => { MessageBox.Show("Shortcut Fired"); }, (Keys)new KeysConverter().ConvertFrom(comboBox1.Text), checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
    
                checkBox1.Enabled = checkBox2.Enabled = checkBox3.Enabled = comboBox1.Enabled = button1.Enabled = false;
    
                label2.Text = "Go ahead and tryout your Shortcut now ...";
            }
        }
    }
