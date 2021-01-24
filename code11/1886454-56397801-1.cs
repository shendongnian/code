	public void start()
	{
		switch (_step)
		{
			case STEP_INITIAL:
				textBottom.Text = "Enter name:";                    
				_step = STEP_GET_NAME;
				break;
			case STEP_GET_NAME:
				_name = textTop.Text;
				if (string.IsNullOrWhiteSpace(_name))
					MessageBox.Show("Please enter a valid name!");
				else
				{
					textBottom.Text = "Enter description:";
					textTop.Clear();
					_step = STEP_GET_DESCRIPTION;
				}
				break;
			case STEP_GET_DESCRIPTION:
				_description = textTop.Text;
				if (string.IsNullOrWhiteSpace(_description))
					MessageBox.Show("Please enter a valid description!");
				else
				{
					//This is your final state, where they have entered all the information
					_step = STEP_INFO_GATHERED;
				}
				break;
		}                       
	}
