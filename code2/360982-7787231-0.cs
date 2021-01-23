    public class Perms {
        List<object> perms = new List<object>();
        public bool HasPermission<T>(T perm) {
            return perm == (GetPerm(typeof(T)) & perm);
        }
        dynamic GetPerm(Type param1) {
            foreach(var item in perms) {
                if(item.GetType() == param1)
                    return item;
            }
            throw new Exception();
        }
    }
