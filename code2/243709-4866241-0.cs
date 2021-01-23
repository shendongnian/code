    protected void LocationValidator_ServerValidate(object source, ServerValidateEventArgs args)
    		{
    			args.IsValid = IsCountryValid();
    		}
    
    		private bool IsCountryValid()
    		{
    			if (Country.SelectedValue == "US")
    			{
    				if (String.IsNullOrEmpty(City.Text))
    					return false;
    
    				if (String.IsNullOrEmpty(State.SelectedValue))
    					return false;
    
    				if (String.IsNullOrEmpty(Zip.Text))
    					return false;
    			}
    			else if (String.IsNullOrEmpty(Country.SelectedValue))
    			{
    				return false;
    			}
    
    			return true;
    		}
