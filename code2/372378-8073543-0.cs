    public class User
    {
        private List<IRole> roles_ = new List<IRole>();
        /* .. usual suspects */
        public void AddRole(IRole role)
        {
            Debug.Assert(role != null);
            Debug.Assert(!HasRole(role));
            roles_.Add(role);
        }
        public void RevokeRole(IRole role)
        {
            Debug.Assert(role != null);
            roles_.Remove(role);
        }
        public bool HasRole(IRole role)
        {
             Debug.Assert(role);
             return roles_.Contains(role);
        }
        public bool CanPerform(IAction action)  /* to come */ 
    }  // eo class User
