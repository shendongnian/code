public static string FilterText
{
   get { return _filterText; }
   set
   {
      _filterText = value;
      ICollectionView.Filter = FilterBoth;
   }
}
public static Model1 PublicModelProperty
{
   get { return _publicModelProperty; }
   set
   {
      _publicModelProperty = value;
      ICollectionView.Filter = FilterBoth;
   }
}
public static bool FilterBoth(object names)
{
	Model2 name = names as Model2;	
	bool result = true;
	if(!string.IsNullOrEmpty(FilterText))
	{
		if (name.Property1.Contains(FilterText) ||
				name.Property2.Contains(FilterText))
			return true;
		result = false;
	}	
	if (!string.IsNullOrEmpty(PublicModelProperty.Property))
	{
		if (name.Property1.Contains(PublicModelProperty.Property))
			return true;
		result = false;
	}
	return result;
}
