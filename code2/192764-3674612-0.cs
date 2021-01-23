	public static void ComboItemsFromEnum<EnumType>(ComboBox combobox) where EnumType : struct
	{
		combobox.FormattingEnabled = true;
		foreach (object enumVal in System.Enum.GetValues(typeof(EnumType)))
		{
			combobox.Items.Add(enumVal);
		}
		combobox.Format += delegate(object sender, ListControlConvertEventArgs e)
		{
			e.Value = GetDescription<EnumType>(e.Value);
		};
	}
