    using CsvHelper;
    using CsvHelper.TypeConversion;
    using CsvHelper.Configuration;
    public class CustomInt32Converter: Int32Converter {
    	public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    	{
    		if (text == "N/A") return 0;
    		return base.ConvertFromString(text, row, memberMapData);
    	}
    }
