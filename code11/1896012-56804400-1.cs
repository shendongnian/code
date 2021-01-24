    int jobNumber = 0;
    int itemNumber = 0;
    string Qty = "Qty";
    string itemMake = "itemMake";
    string itemModel = "itemModel";
    string itemSerial = "itemSerial";
    string itemType = "itemType";
    string specs = "specs";
    string fault = "fault";
    string Assessor = "Assessor";
    string replacementQuote = "replacementQuote";
    string replacementPrice = "replacementPrice";
    string totalPrice = "totalPrice";
    int maxLen = itemMake.Length;
    if (itemModel.Length > maxLen) maxLen = itemModel.Length;
    if (itemSerial.Length > maxLen) maxLen = itemSerial.Length;
    if (itemType.Length > maxLen) maxLen = itemType.Length;
    if (specs.Length > maxLen) maxLen = specs.Length;
    if (fault.Length > maxLen) maxLen = fault.Length;
    if (replacementQuote.Length > maxLen) maxLen = replacementQuote.Length;
    if (replacementPrice.Length > maxLen) maxLen = replacementPrice.Length;
    if (totalPrice.Length > maxLen) maxLen = totalPrice.Length;
    string formatter = "";
    for (int i = 0; i < 4; i++)
    {
        formatter += $"{"{"}{i},{-maxLen}{"}"}";
    }
    // Use for loop to make rows
    string formattedText = string.Format(formatter, itemMake, specs, fault, replacementPrice) +
        Environment.NewLine +
        string.Format(formatter, itemModel, "", "", replacementQuote) +
        Environment.NewLine +
        string.Format(formatter, itemSerial, "", "", totalPrice);
        
