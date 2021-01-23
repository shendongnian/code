    txtDesc.Text = "Blue Cross Blue Shield";
    string TargetString = txt.Desc.Text;
    string MainString = TargetString;
    for (int i = 0; i < txtDesc.Length; i++)
    {
    	if (char.IsLower(txtDesc[i]))
    	{
    		txtDesc.Replace(txtDesc[i], '');
    	}
    }
    Console.WriteLine("The string {0} has converted to {1}", MainString, TargetString);
