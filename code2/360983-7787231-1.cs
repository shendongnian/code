    public class Perms {
        List<object> perms = new List<object>();
        public bool HasPermission<T>(T perm) {
            return perm == (GetPerm(typeof(T)) & perm);
        }
        dynamic GetPerm(Type permType) {
            foreach(var item in perms) {
                if(item.GetType() == permType)
                    return item;
            }
            throw new Exception();
        }
    }
