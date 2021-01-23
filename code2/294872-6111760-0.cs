    string input = @"<TestItem1Request>
      <Username>admin</Username>
      <Password>123abc..@!</Password>
      <Item1>this is an item</Item1>
    </TestItem1Request>";
    
    string result = XElement.Parse(input).ToString(SaveOptions.DisableFormatting);
    Console.WriteLine(result);
