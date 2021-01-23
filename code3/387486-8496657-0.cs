            int TotalCompleted;
            int TotalToComplete;
            string mySQL;
            OleDbCommand datacommand;
            object oValue;
    
            mySQL = " SELECT COUNT(tblOrderAA.orderAASerialPro) AS orderAASerialPro1 FROM tblOrderAA WHERE tblOrderAA.orderAASerialPro=" + Convert.ToInt32(serialPro.Text);
            datacommand = new OleDbCommand(mySQL, myConnection);
            oValue = datacommand.ExecuteScalar();
            if (oValue != DBNull.Value)
            {
                TotalCompleted = (int)oValue;
            } else 
            {
                TotalCompleted = 0;
            }
            mySQL = "SELECT tblProInfo.proInfoSerialNum FROM tblProInfo WHERE tblProInfo.proInfoSerialNum=" + Convert.ToInt32(serialPro.Text);
            datacommand = new OleDbCommand(mySQL, myConnection);
            oValue = datacommand.ExecuteScalar();
            if (oValue != DBNull.Value)
            {
                TotalToComplete = (int)oValue;
            } else 
            {
                TotalToComplete = 0;
            }
            if (TotalCompleted == TotalToComplete)
            {
                MessageBox.Show("You have entered all the amino acids for this protein", "Attention",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                Reset_Click(sender, e);
            }
