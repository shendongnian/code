    txtDesc.Text = "Blue Cross Blue Shield";
    string TargetString = txt.Desc.Text;
    string MainString = TargetString;
    for (int i = 0; i < TargetString.Length; i++)
    {
    	if (char.IsLower(TargetString[i]))
    	{
    		TargetString = TargetString.Replace( TargetString[ i ].ToString(), string.Empty );
    	}
    }
    Console.WriteLine("The string {0} has converted to {1}", MainString, TargetString);
