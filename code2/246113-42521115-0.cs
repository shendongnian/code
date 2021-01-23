    public class IgnoreSomePropertyConvention : ConventionBase, IMemberMapConvention
    {
        public void Apply(BsonMemberMap memberMap)
        { // more checks will go here for the case above, e.g. type check
            if (memberMap.MemberName != "DoNotWantToSaveThis")
                memberMap.SetShouldSerializeMethod(o => false);
        }
    }
