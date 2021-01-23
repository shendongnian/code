    public sealed class PhoneBook // a singleton
    {
        Object comObject;
        Type type;
        private readonly static PhoneBook _instance = new PhoneBook();
        public static PhoneBook Instance  { get { return _instance; } }
        private PhoneBook()
        {
            var t = Type.GetTypeFromProgID("WinFax.SDKPhoneBook");
            if (t == null)
                throw new ArgumentException("WinFax Pro is not installed.");
            comObject = Activator.CreateInstance(t);
            type = comObject.GetType();
        }
        public string GetUserGroupFirst(int flavor, string id)
        {
            var parameters = new Object[2];
            parameters[0] = flavor;
            parameters[1] = id;
            string s = type.InvokeMember("GetUserGroupFirst",
                                         BindingFlags.InvokeMethod,
                                         null,
                                         comObject,
                                         parameters) as String;
            return s;
        }
    ....
