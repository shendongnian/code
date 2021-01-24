        public int count(string s,string ch)        //s is the string and ch is the char to look for
    {
        int count = 0;
        for (int i = 0; i < s.Length; i++)
            if(s[i]==ch[0])
                count++;
        return count;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (tbString.Text != "" && tbChar.Text != "")
            tbCount.Text = count(tbString.Text, tbChar.Text).ToString();
    }
}
