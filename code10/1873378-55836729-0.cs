    if (myDictionary.ContainsKey("Apple"))
    {             
       BtnName.InnerText = AlertDic["Apple"].Split(',').Length.ToString();
    }
    
    if (myDictionary.ContainsKey("Samsung"))
    {
       BtnName.InnerText = AlertDic["Samsung"].Split(',').Length.ToString();
    }
    
    if (myDictionary.ContainsKey("Blackberry"))
    {
       BtnName.InnerText = AlertDic["Blackberry"].Split(',').Length.ToString();
    }
