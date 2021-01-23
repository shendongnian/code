    try 
    {
        // code
    }
    catch
    {
        foreach (var issue in std.GetRuleViolations())
        {
            ModelState.AddModelError(issue.PropertyName, issue.ErrorMessage);
        }
    }
