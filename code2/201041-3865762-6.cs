	public bool LoadPostData(string postDataKey,
	    System.Collections.Specialized.NameValueCollection postCollection)
	{
		bool oldValue = _isChecked;
		postCollection = HttpContext.Current.Request.Form; // See note below
		_isChecked = (postCollection[this.GroupName] == this.Text);
		return oldValue == _isChecked;
	}
