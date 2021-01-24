    string myHobbies { get; set; } 
    protected void CheckBox_CheckedChanged(object sender, EventArgs e)
    {
         List<CheckBox> hobbyCheckBoxList = new List<CheckBox>();
         hobbyCheckBoxList.Add(CheckBox1);
         hobbyCheckBoxList.Add(CheckBox2);
         hobbyCheckBoxList.Add(CheckBox3);
         hobbyCheckBoxList.Where(x => x.Checked).Select(x=>x.Text);
         myHobbies.Text = string.Join(",", hobbyCheckBoxList.Where(x => x.Checked).Select(x => x.Text));
    }
