    public class VATGridViewTextBoxCell : DataGridViewTextBoxCell
	{
		protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
		{
			Price.VATRateEnum r = (Price.VATRateEnum)(int)value;
			switch (r)
			{
				case Price.VATRateEnum.None: return "0%";
				case Price.VATRateEnum.Low: return "14%";
				case Price.VATRateEnum.Standard: return "20%";
				default:
					throw new NotImplementedException()
			}
		}
	}
