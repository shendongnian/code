    private class CustomXamlSchemaContext : XamlSchemaContext
    {
        public override XamlType GetXamlType(Type type)
        {
            var xamlType = base.GetXamlType(type);
            return new CustomXamlType(xamlType.UnderlyingType, xamlType.SchemaContext, xamlType.Invoker);
        }
    }
    private class CustomXamlType : XamlType
    {
        public CustomXamlType(Type underlyingType, XamlSchemaContext schemaContext, XamlTypeInvoker invoker)
            : base(underlyingType, schemaContext, invoker)
        {
        }
        protected override bool LookupIsConstructible()
        {
            return true;
        }
        protected override XamlMember LookupMember(string name, bool skipReadOnlyCheck)
        {
            var member = base.LookupMember(name, skipReadOnlyCheck);
            return member == null ? null : new CustomXamlMember((PropertyInfo)member.UnderlyingMember, SchemaContext, member.Invoker);
        }
        protected override IEnumerable<XamlMember> LookupAllMembers()
        {
            foreach (var member in base.LookupAllMembers())
            {
                var value = new CustomXamlMember((PropertyInfo)member.UnderlyingMember, SchemaContext, member.Invoker);
                yield return value;
            }
        }
        protected override bool LookupIsPublic()
        {
            return true;
        }
    }
    private class CustomXamlMember : XamlMember
    {
        public CustomXamlMember(PropertyInfo propertyInfo, XamlSchemaContext schemaContext, XamlMemberInvoker invoker)
            : base(propertyInfo, schemaContext, invoker)
        {
        }
        protected override bool LookupIsReadOnly()
        {
            return false;
        }
        protected override bool LookupIsWritePublic()
        {
            return true;
        }
    }
