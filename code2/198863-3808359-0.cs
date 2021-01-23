    ThrowHelper.IfNullAndNullsAreIllegalThenThrow<T>(item, ExceptionArgument.item);
    try
    {
        this.Add((T) item);
    }
    catch (InvalidCastException)
    {
        ThrowHelper.ThrowWrongValueTypeArgumentException(item, typeof(T));
    }
