    public IEnumerable<RuleViolation> GetRuleViolations()
    {
        if (!String.IsNullOrEmpty(this.Phone) && !Utility.IsValidPhoneNumber(this.Phone))
        {
            yield return new RuleViolation("Phone is invalid. Try this format: ###-###-####.", "HomePhone");
        }  
        yield break;         
    }
