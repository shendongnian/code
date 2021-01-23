    int _total = 0;
    
    public Form1()
    {
        InitializeComponent();
        textBox1.KeyPress += textBox1_KeyPress;
    }
    
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            int currentVal;
            if(!int.TryParse(textBox1.Text, out currentVal))
                 return;
            _total += currentVal;
            textBox1.Clear();
            MessageBox.Show(_total.ToString());
        }
    }
