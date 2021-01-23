    StringBuilder messageBuilder = new StringBuilder(200);
    
    messageBuilder.Append("To continue, please select one of the actions below:");
    messageBuilder.Append(Environment.NewLine);
    messageBuilder.Append(Environment.NewLine);
    messageBuilder.Append("\t\u2022 Click Button A to do this action.");
    messageBuilder.Append(Environment.NewLine);
    messageBuilder.Append("\t\u2022 Click Button B to do this action.");
    
    MessageBox.Show(messageBuilder.ToString());
