    public static class MethodExt {
        static MethodInfo MemberInfo<T1, T2>(Action d) {
           return d.Method;
        }
        // other overloads ...
    }
