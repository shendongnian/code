        private void button1_Click(object sender, EventArgs e)
        {
            UserControlA ucA = new UserControlA();        
            panel1.Controls.Add(ucA);
            ucA.WireUserControl();
        }
