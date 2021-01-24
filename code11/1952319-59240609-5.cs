	if (e.PropertyDescriptor is PropertyDescriptor propDesc)
    {
        foreach (Attribute att in propDesc.Attributes)
        {
		    if(att is YourCustomAttrbute customAttr)
			{
			   // do something
			}
		}
	}
