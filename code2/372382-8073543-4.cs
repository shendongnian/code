    public sealed class RoleValidation
    {
        private Dictionary<System.Type, List<IAction>> roleMap_ = new Dictionary<System.Type, List<IAction>>(); // this is our mapping of roles to actions
        // ctor ignored for brevity
        public void AssignActionToRole<ROLE>(IAction action)
        {
            Debug.Assert(action != null);
            if(roleMap_.ContainsKey(typeof(ROLE)))
                roleMap_[typeof(ROLE)].Add(action);
            else
            {
                List<IAction> actions = new List<IAction>();
                actions.Add(action);
                roleMap_[typeof(ROLE)] = actions;
            }
        }
        // Nice generic function for ease of use
        public List<IAction> GetActions<ROLE>() where ROLE : IRole
        {
            foreach(KeyValuePair<System.Type, IAction> pair in roleMap_)
            {
                if(typeof(ROLE).IsAssignableFrom(pair.Key.GetType()))
                    return pair.Value;
            }
            return null;
        }
        // for everyone else, non-explicit
        public List<IAction> GetActions(System.Type type)
        {
            foreach(KeyValuePair<System.Type, IAction> pair in roleMap_)
            {
                if(type.IsAssignableFrom(pair.Key.GetType()))
                    return pair.Value;
            }
            return null;
        }
    } // eo class RoleValidation
