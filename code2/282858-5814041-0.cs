        private int checkCounter;
        private void OnCheckedChanged(object sender, EventArgs e)
        {
            // Increase or decrease the check counter
            CheckBox box = (CheckBox) sender;
            if (box.Checked)
                checkCounter++;
            else
                checkCounter--;
            // prevent checking
            if (checkCounter == 4)
            {
                MessageBox.Show("YOU ARE EVIL", "Bad");
                box.Checked = false;
            }
        }
