    var exclusions = new HashSet<T>();
    foreach (string s in txtNumbersToBeExc.Text.Split(new string[] { Environment.NewLine })
    {
        int value;
        if (int.TryParse(s, value)
        {
            exclusions.Add(value);
        }
    }
    var output = new StringBuilder();
    for (int i = int.Parse(txtStartSeed.Text); i <= int.Parse(txtEndSeed.Text); i++)
    {
        if (!exclusions.Contains(i))
        {
            output.AppendFormat("959{0}\n", i);
        }
    }
    
    txtGeneratedNum.Text = output.ToString();
   
