    public object getValue(String memberName) {
        var member = this.GetType().GetMember(memberName);
        if (member.MemberType == MemberTypes.Property) {
             return this.GetType().GetProperty(propertyName).GetValue(this, null);
        }
        if (member.MemberType == MemberTypes.Field) {
            return this.GetType().GetField(fieldName).GetValue(this);
        }
        else
        {
            throw new Exception("Bad member type.");
        }
    }
