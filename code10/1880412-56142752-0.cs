    var lookFor = new [] { MyEnum.A, MyEnum.B, MyEnum.C };
    list.FirstOrDefault(r => r.MyEnumValue == myEnum || (
                                 myEnum == MyEnum.B && lookFor.Contains(r.MyEnumValue)
                             )
                        );
