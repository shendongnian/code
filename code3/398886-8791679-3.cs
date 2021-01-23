    public BusinessRuleException(Exception inner)
    :   base(inner) {
        SetDuplicateDetectedFlag(inner);
    }
    public BusinessRuleException(string message, Exception inner)
    :   base(message, inner) {
        SetDuplicateDetectedFlag(inner);
    }
    private void SetDuplicateDetectedFlag(Exception inner) {
        var innerSql = inner as SqlException;
        DuplicateDetected = innerSql != null && innerSql.Number == 247;
    }
