        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gb1.Enabled = cb1.SelectedIndex == 0;
            gb1.Enabled = cb1.SelectedIndex == 1;
            // Unless you plan to add more cases to the switch,
            // the switch is redundant with the lines above.
            //switch (cb1.SelectedIndex)
            //{
            //    case 0:
            //        gb1.Enabled = true;
            //        gb2.Enabled = false;
            //        break;
            //    case 1:
            //        gb2.Enabled = true;
            //        gb1.Enabled = false;
            //        break;
            //}
        }
