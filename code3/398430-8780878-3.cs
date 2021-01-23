    private void bCheck_Click(object sender, EventArgs e)
    		{
    			bool found = false;
    			foreach (Label l in pole)
    			{
    				if (l.Location == lblCovece.Location && l.Text == txtGoal.Text)
    				{
    					l.BackColor = Color.Green;
    
    					score += int.Parse(l.Text);
    					lblResultE.Text = score.ToString();
    					found = true;
    				}
    			}
    			if (!found)
    			{
    				score -= 10;
    				lblResultE.Text = score.ToString();
    			}
    		}
