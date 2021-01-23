    if (loadOperation.TotalEntityCount >= itemCount || !string.IsNullOrEmpty(FilterText))
    {
    	this.ItemCount = loadOperation.TotalEntityCount;
    }
    else
    {
       	if (!DeleteMember)
    	{
    		pageIndex = (int)((this.ItemCount - loadOperation.TotalEntityCount) / this.PageSize);
    		RaisePropertyChanged("PageIndex");
    	}
    	else
        {
    		DeleteMember = false;
    		itemCount -= 1;
    	}
    }
