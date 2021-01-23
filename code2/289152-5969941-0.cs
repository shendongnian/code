    var formatIssues = issues.Where(i => i.IsFormatError == true);
    var groupIssues = issues.Where(i => i.IsGroupError == true);
    var dupeIssues = issues.Where(i => issues.Except(new List<Issue> {i})
                                            .Any(x => x.ColumnIndex == i.ColumnIndex));
    var filteredIssues = formatIssues.Union(groupIssues).Except(dupeIssues);
