    List<MyEnum> allValues = new List<MyEnum>(Enum.Getvalues(typeof(MyEnum)));
    HashSet<MyEnum> allCombos = new Hashset<MyEnum>();
    
    for(int i = 1; i < (1<<allValues.Count); i++)
    {
        MyEnum working = (MyEnum)0;
        int index = 0;
        int checker = i;
        while(checker != 0)
        {
            if(checker & 0x01 == 0x01) working |= allValues[index];
            checker = checker >> 1;
            index++;
        }
        allCombos.Add(working);
    }
