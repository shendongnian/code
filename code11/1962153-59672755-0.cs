	using System;
	using Xamarin.Forms;
	
	public class KeyboardTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(Type sourceType)
		{
			return sourceType == typeof(string);
		}
		public override object ConvertFromInvariantString(string value)
		{
			switch (value)
			{
				case "Chat": return Keyboard.Chat;
				case "Email": return Keyboard.Email;
				case "Numeric": return Keyboard.Numeric;
				case "Plain": return Keyboard.Plain;
				case "Telephone": case "Phone": return Keyboard.Telephone;
				case "Text": return Keyboard.Text;
				case "Url": return Keyboard.Url;
				default: return Keyboard.Default;
			}
		}
	}
