    public sealed override int GetHashCode()
    {
        if (this.IsUnmanagedFunctionPtr())
        {
            return ValueType.GetHashCodeOfPtr(base._methodPtr);
        }
        object[] objArray = this._invocationList as object[];
        if (objArray == null)
        {
            return base.GetHashCode();
        }
        int num = 0;
        for (int i = 0; i < ((int) this._invocationCount); i++)
        {
            num = (num * 0x21) + objArray[i].GetHashCode();
        }
        return num;
    }
