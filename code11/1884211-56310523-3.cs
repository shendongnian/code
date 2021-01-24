        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControlA ucA = new UserControlA();
            ucA.Dock = DockStyle.Fill;         
            panel1.Controls.Add(ucA);
            ucA.WireControlsOfType<Button>();
        }
