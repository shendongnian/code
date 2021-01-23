    public class User
    {
        /* you know the rest */
        public bool CanPerform(IAction action)
        {
            /* code assumes RoleValidation is available via some method or whatever */
            foreach(IRole role in roles_)
            {
                if(RoleValidation.Instance.GetActions(typeof(role)).Contains(action))
                    return true;
            }
            return false;
        }
    }
