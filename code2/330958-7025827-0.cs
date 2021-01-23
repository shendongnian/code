    private void button1_Click(object sender, EventArgs e) {
    			_radioContainer.Controls.OfType<RadioButton>().ToList().ForEach(p => p.Checked = false);
    
    			foreach (RadioButton radio in _radioContainer.Controls.OfType<RadioButton>().ToList()) {
    				if (radio.Checked == true) {
    					radio.Checked = false;
    					break;
    				}
    			}
    		}
