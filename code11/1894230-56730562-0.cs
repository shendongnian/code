      var a = new Regex("(?<PageNumber>.{2})(?<ListType>.{2})", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
        
                    GroupCollection groups = aee.Match("02KLThisIsATest").Groups;
                    var names = a.GetGroupNames();
    foreach (var grpName in cc)
                {
                    Console.WriteLine("Group: {0}, Value: {1}", grpName, groups[grpName].Value);
                }
