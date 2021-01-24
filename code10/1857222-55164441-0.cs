    private void button1_Click(obj sender,EventArgs e)
    {
    String str = "|1|,|2|,|3|,|4|...";
    char[] ch =str.ToArray(),weekList=new char[ch.Length];
    Int index=1;
    for (int i=1;i < ch.Length ;i++)
    {
    if(index < ch.length-1)
    {
    weekList[i] = ch[index];
    Index += 4;
    }
    }
    MessageBox.Show(weekList[0]);//1
    MessageBox.Show(weekList[9]);//10
    }
