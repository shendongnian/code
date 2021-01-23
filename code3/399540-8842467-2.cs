        protected void Page_Load(object sender, EventArgs e)
        {
            createStuff(false);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ViewState["num"] = TextBox1.Text;
            createStuff(true);
        }
        private void createStuff(bool btnClick)
        {
            PlaceHolder1.Controls.Clear();
            int numBtn = Convert.ToInt32(ViewState["num"]);
            for (int i = 0; i < numBtn; i++)
            {
                MyControl temp2 = LoadControl("MyControl.ascx") as MyControl;
                temp2.ID = "uc" + i;
                temp2.MetaData = "meta" + i;
                //not sure why this DOES work, i would think it is overwritten each page load >.<
                temp2.OldText = "old" + i;
                if (btnClick)
                {
                    temp2.NewText = "old" + i;
                    //not sure why this doesnt work below this line
                    //temp2.OldText = "old" + i;
                }
                //also not sure why this won't work
                //temp2.OldText = temp2.NewText;
                PlaceHolder1.Controls.Add(temp2);
            }
        }
