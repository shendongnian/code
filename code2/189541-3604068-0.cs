    private void button1_Click(object sender, EventArgs e)
    {
        int answer;
        int num1 = !string.IsNullOrEmpty(num100.Text)? int.Parse(num100.Text):0;
        int num2 = !string.IsNullOrEmpty(num200.Text)? int.Parse(num200.Text):0;
        //etc...
        answer = (num1 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9 +num10)/10;
        MessageBox.Show(answer.ToString());
