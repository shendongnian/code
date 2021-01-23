    public enum Permission
    {
        Default = 0,
        Disallow = 0,
        Allow = 1,
    }
    public class PermissionMap : DataTable
    {
        private Dictionary<string, int> actionMap = new Dictionary<string, int>();
        public PermissionMap(IEnumerable<string> actions)
        {
            Columns.Add(new DataColumn("Action"));
            int i = 0;
            foreach (var action in actions)
            {
                actionMap.Add(action, i++);
                var row = NewRow();
                row["Action"] = action;
                Rows.Add(row);
            }
        }
        public void AddUser(string user)
        {
            Columns.Add(new DataColumn(user));
            foreach (DataRow row in Rows)
                row[user] = Permission.Default;
        }
        public Permission this[string user, string action]
        {
            get { return (Permission)Rows[actionMap[action]][user]; }
            set { Rows[actionMap[action]][user] = value; }
        }
    }
