    if (id > 0)
    {
        context.HttpContext.Request.Path = (string.Format("/Dokument/{0}", id));
        context.Result = RuleResult.SkipRemainingRules;
    }
