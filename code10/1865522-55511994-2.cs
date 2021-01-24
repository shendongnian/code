        public class ActivityComparer : IEqualityComparer<TbUserActivity>
        {
            public bool Equals(TbUserActivity x, TbUserActivity y)
            {
                if (x == null && y == null)
                    return true;
                else if (x == null || y == null)
                    return false;
                return x.name == y.name 
            }
            public int GetHashCode(TbUserActivity obj)
            {
                return obj.userActivityId;
            }
        }
