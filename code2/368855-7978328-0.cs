    class Program
    {
        static void Main(string[] args)
        {
        }
        public static MemberName SplitTdsName(string tdsName)
        {
            NameSplitter preSplitName = new NameSplitter(tdsName);
            return preSplitName.GetMemberName();
        } 
    }
    public struct MemberName
    {
        public string Title;
        public string FirstNames;
        public string LastNames;
        public MemberName(string title, string firstNames, string lastNames)
        {
            Title = title;
            FirstNames = firstNames;
            LastNames = lastNames;
        }
    }
    public class NameSplitter
    {
        MemberName _memberName;
        public NameSplitter(string fullName)
        {
            _memberName = new MemberName("title", "firstName", "lastName");
        }
        public MemberName GetMemberName()
        {
            return _memberName;
        }
    }
