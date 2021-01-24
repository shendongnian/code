    protected void Display_Btn_Click(object sender, EventArgs e)
    {
                if(radCalifornia.Checked)
                {
                    Label1.Text = "Sacramento";
                }
                else if(radCarolina.Checked)
                {
                    Label1.Text = "Raleigh";
                }
                else if (radFlorida.Checked)
                {
                    Label1.Text = "Tallahassee";
                }
     }
