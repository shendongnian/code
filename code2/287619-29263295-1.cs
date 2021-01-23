    enum MyEnum {A, B};
    class TestEnum
    {
        // Static constructor
        static TestEnum()
        {
            // Check if this code needs updating as the enum has changed
            if (Enum.GetNames(typeof(MyEnum)).Length != 2)
            {
                // If this fails update myFunction and the number above
                throw new Exception("Internal error - code inconsistency");
            }
        }
        // My function that switches on the enum
        string myFunction(MyEnum myEnum)
        {
            switch (myEnum)
            {
                case MyEnum.A: return "A";
                case MyEnum.B: return "B";
            }
            throw new Exception("Internal error - missing case");
        }
    }
