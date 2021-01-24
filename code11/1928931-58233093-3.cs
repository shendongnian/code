     var commandList = new Dictionary<string, Action>();
                commandList.Add("command1", () => { Console.WriteLine("command1 is executed"); });
                commandList.Add("command2", () => { Console.WriteLine("command2 is executed"); });
                commandList.Add("command3", () => { Console.WriteLine("command3 is executed"); });
                var listOfUserCommands = new Dictionary<string, List<string>>();
                listOfUserCommands.Add("user1", new List<string>() { "command1" });
                listOfUserCommands.Add("user2", new List<string>() { "command2", "command3" });
    
                var userName = "user1";
                var commandName = "command2";
                if (listOfUserCommands.ContainsKey(userName) && listOfUserCommands[userName].Contains(commandName))
                {
                    commandList[commandName]();
                }
