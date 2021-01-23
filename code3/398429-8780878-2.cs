    private void bCheck_Click(object sender, EventArgs e)
    		{
    			foreach (Label l in pole)
    			{
    				if (l.Location == lblCovece.Location && l.Text == txtGoal.Text)
    				{
    					l.BackColor = Color.Green;
    					
    					score += int.Parse(l.Text);
                                        lblResultE.Text = score;
    				}
    				else
    				{
    					score -= 10;
    				}
    			}
    		}
