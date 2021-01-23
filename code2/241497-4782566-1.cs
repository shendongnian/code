        TestEnum testEnum;
        if( Enum.IsDefined(typeof(TestEnum), "FirstValue") )
        {
            testEnum = (TestEnum)Enum.Parse(typeof(TestEnum), "FirstValue");
        }
