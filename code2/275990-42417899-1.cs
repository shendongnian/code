    private void Form1_Load(object sender, EventArgs e)
    {
        comboBox1.DataSource = Enum.GetValues( typeof(Gender));
        Array gen = Enum.GetValues(typeof(Gender));
        List<KeyValuePair<string, char>> lstgender = new List<KeyValuePair<string,char>>();
        foreach(Gender g in gen)
            lstgender.Add(new KeyValuePair<string,char>(g.ToString(),((char)g)));
        comboBox1.DataSource = lstgender;
        comboBox1.DisplayMember = "key";
        comboBox1.ValueMember = "value"
    }
    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show(comboBox1.SelectedValue.ToString());
    }
    public class Student
    {
        public string stud_name { get; set; }
        public Gender stud_gen { get; set; }
    }
    public enum Gender
    {
        Male='M',
        Female='F'
    }
