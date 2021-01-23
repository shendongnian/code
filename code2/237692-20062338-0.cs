 	/// <summary>
	/// Set the Browsable property.
	/// NOTE: Be sure to decorate the property with [Browsable(true)]
	/// </summary>
	/// <param name="PropertyName">Name of the variable</param>
	/// <param name="bIsBrowsable">Browsable Value</param>
	private void setBrowsableProperty(string strPropertyName, bool bIsBrowsable)
	{
		// Get the Descriptor's Properties
		PropertyDescriptor theDescriptor = TypeDescriptor.GetProperties(this.GetType())[strPropertyName];
			
		// Get the Descriptor's "Browsable" Attribute
		BrowsableAttribute theDescriptorBrowsableAttribute = (BrowsableAttribute)theDescriptor.Attributes[typeof(BrowsableAttribute)];
		FieldInfo isBrowsable = theDescriptorBrowsableAttribute.GetType().GetField("Browsable", BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance);
			
		// Set the Descriptor's "Browsable" Attribute
		isBrowsable.SetValue(theDescriptorBrowsableAttribute, bIsBrowsable);
	}
