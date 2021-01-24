    private void Form1_Load(object sender, EventArgs e)
    {
        comboBox1.DisplayMember = "CountryAndCode";
        comboBox1.ValueMember = "CountryCode";
        comboBox1.DataSource = countryCodes;
        comboBox1.SelectedIndex = -1;
        comboBox1.SelectedIndexChanged += (o, ev) => {
            if (comboBox1.SelectedIndex < 0) return;
            comboBox1.BeginInvoke(new Action(() => {
                comboBox1.Text = comboBox1.SelectedValue.ToString();
            }));
        };
    }
    private List<CountryCode> countryCodes = new List<CountryCode>() {
        new CountryCode() { CountryName = "USA", CountryCode = "+1" },
        new CountryCode() { CountryName = "Canada", CountryCode = "+1" },
        new CountryCode() { CountryName = "Argentina", CountryCode = "+54"},
        new CountryCode() { CountryName = "Brasil", CountryCode = "+55"}
    };
