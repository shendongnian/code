    private object System.Collections.IList.Item
    {
        get
        {
            return this[index];
        }
        set
        {
            ThrowHelper.IfNullAndNullsAreIllegalThenThrow<T>(value, ExceptionArgument.@value);
            try
            {
                this.Item = index;
            }
            catch (InvalidCastException)
            {
                ThrowHelper.ThrowWrongValueTypeArgumentException(value, typeof(T));
            }
        }
    }
