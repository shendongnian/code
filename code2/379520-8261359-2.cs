	private object m_Value;
	[TypeConverter(typeof(StringToObjectConverter))]
	public object Value
	{
		get
		{
			return m_Value;
		}
		set
		{
			if (value is MyObjectConverter)
			{
				m_Value = ((MyObjectConverter)value).Value;
			}
			else
			{
				m_Value = value;
			}
		}
	}
