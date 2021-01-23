    [ComVisible(true)]
    [Guid("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IDynamicModel
    {
        dynamic this[string propertyName] { get; set; }
        bool TryGetMember(GetMemberBinder binder, out object result);
        bool TrySetMember(SetMemberBinder binder, object value);
    }
