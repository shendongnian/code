    BaseClass baseClass = new SubClass();
    if (baseClass is SubClass)
    {
        SubClass subClass = baseClass as SubClass;
        subClass.Method();
    }
