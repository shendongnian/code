    private void bCheck_Click(object sender, EventArgs e)
    		{
    			foreach (Label l in pole)
    			{
    				if (l.Location == lblCovece.Location && l.Text == txtGoal.Text)
    				{
    					lblCovece.BackColor = Color.Green;
    					lblResultE.Text = l.Text;
    					//Increase score here
    				}
    				else
    				{
    					//Decrease score
    				}
    			}
    		}
