    public bool ApplyRules(List<Rule> rules, User user)
    {
        foreach (var rule in rules)
        {
            IComparable value = null;
            object limit = null;
            if (rule.objectProperty == "age")
            {
                value = user.age;
                limit = Convert.ToInt32(rule.TargetValue);
            }
            else if (rule.objectProperty == "username")
            {
                value = user.username;
                limit = rule.TargetValue;
            }
            else
                throw new InvalidOperationException("invalid property");
            int result = value.CompareTo(limit);
            if (rule.ComparisonOperator == "equal")
            {
                if (!(result == 0)) return false;
            }
            else if (rule.ComparisonOperator == "greater_than")
            {
                if (!(result > 0)) return false;
            }
            else
                throw new InvalidOperationException("invalid operator");
        }
        return true;
    }
