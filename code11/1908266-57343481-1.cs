    StringBuilder sbResults = new StringBuilder();
    for(int i = num1; i  > 40; i--)
    {
       // Each loop iteration here is one hour over 40 hours
       sbResults.AppendLine("Bonus!");
    }
    YourMultilineControl.Text = sbResults.ToString();
