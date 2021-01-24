	public static string CombineCheckboxLists(params CheckBoxList[] list)
	{
		StringBuilder sb = new StringBuilder();
		
		foreach (CheckBoxList checkBoxList in list)
		{
			int counter = checkBoxList.Items.Count;
			for (int i = 0; i < counter; i++)
				sb.Append(string.Join(",", checkBoxList.Items[i].Selected ? checkBoxList.Items[i].Text : ""));
		}
		return sb.ToString();
	}
