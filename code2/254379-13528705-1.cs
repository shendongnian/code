        try
        {
            for (int i = 0; i < skype.HardwiredGroups.Count; i++)
                if (skype.HardwiredGroups[i + 1].Type == TGroupType.grpAllFriends)
                {
                    for (int j = skype.HardwiredGroups[i + 1].Users.Count; j > 0; j--)
                        Console.WriteLine(skype.HardwiredGroups[i + 1].Users[j].Handle);
                    break;
                }
        }
        catch (Exception e)
        {
            Console.WriteLine("Display Friends Group Error- Exception Source: " + e.Source + " - Exception Message: " + e.Message);
        }
