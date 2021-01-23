    If(TReturn.IsValueType)
    {
          If(TReturn.IsEnum) Cast to Enum base type using Convert.To(base), then to Enum.
          If(TReturn.IsNullable<>) Cast to Nullable<> generic type  using Convert.To(base), then to Nullable<T>
          If(TReturn.ISNullableEnum) Cast to Enum base type  using Convert.To(base), then to Nullable enum.
          Otherwise, just call Convert.To(TReturn) if that method exists.
    }
    If it's Iconvertible try calling Convert.ChangeType(object,Type) and cast as TReturn.
    If no method has been found yet, try doing an explicit cast TReturn.
