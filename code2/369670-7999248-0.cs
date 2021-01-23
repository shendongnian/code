    var xmlActions = XElement.Parse(GetXmlString());
    IList<string> actionsFromDatabase = GetActionsFromDatabase();
    
    int actionCount = xmlActions.Descendants("Transaction").Count();
    
    foreach (var action in actionsFromDatabase)
                {
                    if (xmlActions.Descendants().Any(el => el.Name == "ActionType" && el.Value == action))
                    {
                        actionCount--;
                    }
                }
