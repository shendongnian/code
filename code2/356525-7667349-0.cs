    class MyControl
    {
        public TextBox txt1 { get; set; }
        public TextBox txt2 { get; set; }
        public TextBox txt3 { get; set; }
        public TextBox txt4 { get; set; }
        public CheckBox cb { get; set; }
        public MyControl(TextBox txt1, TextBox txt2, TextBox txt3, TextBox txt4, CheckBox cb)
        {
            this.txt1 = txt1;
            this.txt2 = txt2;
            this.txt3 = txt3;
            this.txt4 = txt4;
            this.cb = cb;
        }
    }
        List<MyControl> list = new List<MyControl>();
        public int x = 50, n = 1;
        TextBox txtTemp, txt1, txt2, txt3, txt4;
        CheckBox cbTemp;
        private void btn_Click(object sender, EventArgs e)
        {
            txtTemp = new TextBox();
            txtTemp.Location = new System.Drawing.Point(10, x);
            txtTemp.Name = "txt1_" + n;
            txt1 = txtTemp;
            txtTemp = new TextBox();
            txtTemp.Location = new System.Drawing.Point(120, x);
            txtTemp.Name = "txt2_" + n;
            txt2 = txtTemp;
            txtTemp = new TextBox();
            txtTemp.Location = new System.Drawing.Point(230, x);
            txtTemp.Name = "txt3_" + n;
            txt3 = txtTemp;
            txtTemp = new TextBox();
            txtTemp.Location = new System.Drawing.Point(350, x);
            txtTemp.Name = "txt4_" + n;
            txt4 = txtTemp;
            cbTemp = new CheckBox();
            cbTemp.Name = "cb1_" + n;
            cbTemp.Enter += new EventHandler(cbTemp_Enter);
            cbTemp.Location = new System.Drawing.Point(490, x);
            this.Controls.Add(txt1);
            this.Controls.Add(txt2);
            this.Controls.Add(txt3);
            this.Controls.Add(txt4);
            this.Controls.Add(cbTemp);
            list.Add(new MyControl(txt1, txt2, txt3, txt4, cbTemp));
            x += 40;
            n++;
        }
        void cbTemp_Enter(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you Sure?", "Warning", MessageBoxButtons.YesNo)) == DialogResult.No)
                return;
            CheckBox cbMain = (CheckBox)sender;
            int index = Search(cbMain);
            this.Controls.Remove(list[index].txt1);
            this.Controls.Remove(list[index].txt2);
            this.Controls.Remove(list[index].txt3);
            this.Controls.Remove(list[index].txt4);
            this.Controls.Remove(list[index].cb);
        }
        private int Search(CheckBox cbMain)
        {
            int temp = 0;
            foreach (MyControl item in list)
            {
                if(cbMain.Name == item.cb.Name)
                    temp = list.IndexOf(item);
            }
            return temp;
        }
