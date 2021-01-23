    public void CodeIsUnique(string code, Action<bool, Exception> action)
    {
        return ObjectContext.CodeIsUnique(code, op =>
            {
                if (op.HasError)
                {
                    action(false, op.Error);
                    op.MarkErrorAsHandled();
                }
                else
                {
                    action(op.Value, null);
                }
            }, null);
    }
