        public class ActivityComparer : IEqualityComparer<TbUserActivity>
        {
            public bool Equals(TbUserActivity x, TbUserActivity y)
            {
                if (x == null && y == null)
                    return true;
                else if (x == null || y == null)
                    return false;
                return x.userActivityId == y.userActivityId &&
                    x.deviceId == y.deviceId &&
                    x.name == y.name &&
                    x.iconResource == y.iconResource;
            }
            public int GetHashCode(TbUserActivity obj)
            {
                return obj.userActivityId;
            }
        }
