    public class ThirdPartyClass
    {
        public virtual  string Fun(string val)
        {
            return "ThirdParty" + val.ToUpper();
        }
    }
    public static class ThripartyExtension
    {
        public static string Fun(this ThirdPartyClass test, int val)
        {
            return "ThirdParty" + val;
        }
    }
}
