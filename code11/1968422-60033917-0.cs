      private void button1_Click(object sender, EventArgs e)
        {
            int min = Convert.ToInt32(txtMin.Text);
            int max = Convert.ToInt32(txtMax.Text);
            if (min > max)
            {
                MessageBox.Show("Minimum cannot be greater than the Maximum.");
                return;
            }
            if (addPartIHRadio.Checked)
            {
                Inhouse inHouse = new Inhouse((Inventory.Parts.Count + 1), apNameBox, apInvBox, apPpuBox, apMinBox, apMaxBox, int.Parse(apMachineBox));
                Inventory.AddPart(inHouse);
            }
            else
            {
                Outsourced outsourced = new Outsourced((Inventory.Parts.Count + 1), apNameBox, apInvBox, apPpuBox, apMinBox, apMaxBox, apMachineBox);
                Inventory.AddPart(outsourced);
            }
            this.Close();
        }
