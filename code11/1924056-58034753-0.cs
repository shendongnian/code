    IEnumerable<IGrouping<string, MemberInfo>> groupByLastName = infoList.GroupBy(info => info.LastName).Select(i => i);
    
    foreach (List<MemberInfo> lastName in groupByLastName)
    {
        foreach (MemberInfo member in lastName)
        {
           allTheInputLastNames.add(member.FirstName);
        }      
    }
