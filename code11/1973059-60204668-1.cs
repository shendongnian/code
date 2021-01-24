     public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
            List<Player> list = new List<Player>();
            private void Form2_Load(object sender, EventArgs e)
            {
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox1.Items.Add(@"F:\pic\1.jpg");
                comboBox1.Items.Add(@"F:\pic\2.jpg");
                list.Add(new Player { name = "1.jpg", attack = 1, critical = 2, currentHP = 3, defense = 4, HP = 10 });
                list.Add(new Player { name = "2.jpg", attack = 3, critical = 5, currentHP = 7, defense = 2, HP = 10 });
            }
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                string name = Path.GetFileName(comboBox1.SelectedItem.ToString());
                Player player = list.Where(p => p.name == name).First();
                txtname.Text = player.name;
                txtattack.Text = player.attack.ToString();
                txtcritical.Text = player.critical.ToString();
                txtcurrenthp.Text = player.currentHP.ToString();
                txtdefense.Text = player.defense.ToString();
                txthp.Text = player.HP.ToString();
                Form1 form1 = (Form1)Application.OpenForms["Form1"];
                form1.Pic.Image = Image.FromFile(comboBox1.SelectedItem.ToString());
                
            }
    
            private void Form2_FormClosed(object sender, FormClosedEventArgs e)
            {
                Form1 form1 = (Form1)Application.OpenForms["Form1"];
                form1.Focus();
            }
        }
