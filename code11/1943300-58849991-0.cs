    public interface IUserRoleService
    {
        List<string> GetValues();
    }
    public class UserRoleService : IUserRoleService
    {
        private List<string> _privateList = new List<string>();
        public List<string> GetValues()
        {
            _privateList.Add("test");
            return _privateList;
        }
    }
