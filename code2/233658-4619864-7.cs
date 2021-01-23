    public object Bar_NullCoalesce
    {
        get { return this._bar ?? new Object(); }
    }
    public object Bar_IntermediateResultVar
    {
        get
        {
            object result = this._bar;
            if (result == null) { result = new Object(); }
            return result;
        }
    }
    public object Bar_TrinaryOperator
    {
        get { return this._bar != null ? this._bar : new Object(); }
    }
