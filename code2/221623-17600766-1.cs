    public List<PropertyInfo> FindProperties(Type TargetType) {
     
         MemberInfo[] _FoundProperties = TargetType.FindMembers(MemberTypes.Property,        
         BindingFlags.Instance | BindingFlags.Public, new
         MemberFilter(MemberFilterReturnTrue), TargetType);
     
         List<PropertyInfo> _MatchingProperties = new List<PropertyInfo>();
     
         foreach (MemberInfo _FoundMember in _FoundProperties)  {
         _MatchingProperties.Add((PropertyInfo)_FoundMember); }
     
         return _MatchingProperties;
     
    }
