    string _errorText;
    
    public override bool ApplyChanges()
    {
    
    
     if (System.Text.RegularExpressions.Regex.IsMatch(validTb.Text, myRegExp))
                {
    		//write you code here in case of valid input
                    return true;
                }
                else
                {
    		_errorMessage = "Not A valid String";
                    return false; 
                }
     
    }
    
    protected override OnPreRender(EventArgs e)
    {
      if (!string.IsNullOrEmpty(_errorText))
      {
        this.Zone.ErrorText =  _errorText;
      }      
      base.OnPreRender(e);
    }
