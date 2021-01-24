    public static class MyClassExt
    {
        public static bool IsActiveCompany(this MyClass myClass)
        {
            return myClass.Company?.Active ?? false;
        }
    }
