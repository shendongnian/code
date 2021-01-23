    public class DelegateEqualityComparer:IEqualityComparer<Delegate>
    {
        public bool Equals(Delegate del1,Delegate del2)
        {
            return (del1 != null) && del1.Equals(del2);
        }
    
        public int GetHashCode(Delegate obj)
        {
                if(obj==null)
                    return 0;
                int result = obj.Method.GetHashCode() ^ obj.GetType().GetHashCode();
                if(obj.Target != null)
                    result ^= RuntimeHelpers.GetHashCode(obj);
                return result;
        }
    }
