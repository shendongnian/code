    public class MemberInfo : Member
    {
        public MemberInfo()
        {
    
        }
    }
    public abstract class Member: IMemberDetails
    {
        public DateTime currentDate = DateTime.Now;;
    }
