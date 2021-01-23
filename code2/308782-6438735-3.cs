    [SuppressUnmanagedCodeSecurity]
        [Guid("f274179c-6d8a-11d2-90fc-00806fa6792c")]
        [InterfaceType(1)]
        public interface IAccount
        {
            byte GroupType { get; set; } // char in native C++ is generally going to be 8 bits, this = C# byte
    }
    IAccount objAccount= new AccountClass();
    ((IAccount)objAccount).GroupType = myValue;
