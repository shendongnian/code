    public class MemberInfoExt {
        public static bool GetCanWrite(this MemberInfo member) {
            switch (member) {
                case FieldInfo mfi:
                    return true;
                case PropertyInfo mpi:
                    return mpi.CanWrite;
                default:
                    throw new ArgumentException("MemberInfo must be if type FieldInfo or PropertyInfo", nameof(member));
            }
        }
        public static void SetValue(this MemberInfo member, object destObject, object value) {
            switch (member) {
                case FieldInfo mfi:
                    mfi.SetValue(destObject, value);
                    break;
                case PropertyInfo mpi:
                    mpi.SetValue(destObject, value);
                    break;
                case MethodInfo mi:
                    mi.Invoke(destObject, new object[] { value });
                    break;
                default:
                    throw new ArgumentException("MemberInfo must be of type FieldInfo, PropertyInfo or MethodInfo", nameof(member));
            }
        }
    }
