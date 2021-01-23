    using System.Globalization;
    private void btn_Click(object sender, EventArgs e)
    {
            TextInfo ChangeCase = new CultureInfo("en-US", false).TextInfo;
            string newText = ChangeCase.ToTitleCase(txt.Text);
            if (newText == "Name")
                MessageBox.Show("Value is Same");
    }
