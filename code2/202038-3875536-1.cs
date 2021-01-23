    public CoreIdentity GetCoreIdentity()
    {
        ExtendedIdentity exId = Identity as ExtendedIdentity;
        if (exId != null)
        {
            // Since exId is actually declared to be of type ExtendedIdentity,
            // the compiler can choose the operator overload accepting
            // an ExtendedIdentity parameter -- so this will work.
            return (CoreIdentity)exId;
        }
        return (CoreIdentity)Identity;
    }
