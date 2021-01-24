    ManualReadTag a = new ManualReadTag(){ SomeProperty = 123 };
    ManualReadTag b = new ManualReadTag(){ SomeProperty = a.SomeProperty };
    ManualReadTag c = a;
    a.Equals(b) //false even though they have identical property values, memory addresses are different
    a.Equals(c); //true
