    public string Parse(List<string> fieldList)
    {
        var fieldPaths = fieldList.Select(x => x.Split('.').ToList());
        var groups = fieldPaths.GroupBy(x => x.First(), x => x.Skip(1));
        return ParseGroups(groups, 1);
    }
    private string ParseGroups(IEnumerable<IGrouping<string, IEnumerable<string>>> groups, int level)
    {
        string indent = new string('\t', level - 1);
        var groupResults = groups.Select(g =>
            !g.First().Any() ? 
                $"\t{indent}{g.Key}: null" :
                $"\t{indent}{g.Key}: " + string.Join(", \n",
                     ParseGroups(g.GroupBy(x => x.First(), x => x.Skip(1)), level + 1))
        );
        return indent + "{\n" + string.Join(", \n", groupResults) + "\n" + indent + "}";
    }
