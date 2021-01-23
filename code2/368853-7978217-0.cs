    public static MemberName SplitTdsName(string tdsName)
        {
            NameSplitter preSplitName = new NameSplitter(tdsName);
            return preSplitName; // I don't understand why you're returning NameSplitter
                                 // when method's return type is MemberName.
        }
