    class YeniForm : Form
    {
        ...
        public void AddButton(Button btn)
        {
            this.flowLayoutPanel1.Controls.Add(btn); // or whatever you need. Calc position for new control, add it to some kind of container (Panel/TableLayoutPanel etc)
        }
    }
    private void btnNotEkle_Click(object sender, EventArgs e)
    {
        YeniForm yeniForm = new YeniForm();
        Button btn = new Button();
        yeniForm.AddButton(btn);
        ...
    }
