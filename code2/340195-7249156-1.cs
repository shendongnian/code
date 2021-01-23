    public object getValue(String memberName) {
        var member = this.GetType().GetMember(memberName);
        if (member.MemberType == MemberTypes.Property) {
             return ((PropertyInfo)member).GetValue(this, null);
        }
        if (member.MemberType == MemberTypes.Field) {
            return ((FieldInfo)member).GetValue(this);
        }
        else
        {
            throw new Exception("Bad member type.");
        }
    }
