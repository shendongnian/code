    class Res<O, R>
    {
        public O value;
        public bool succ;
        public R result;
        public Res()
        {
        }
        static public implicit operator R(Res<O, R> v)
        {
            if (!v.succ)
                throw new ArgumentException("No case condition is true and there is no default block");
            return v.result;
        }
    }
    static class Op
    {
        static public Res<O, R> Case<O, V, R>(this Res<O, R> o, V v, R r)
        {
            if (!o.succ && Equals(o.value, v))
            {
                o.result = r;
                o.succ = true;
            }
            return o;
        }
        static public Res<O, R> Case<O, V, R>(this O o, V v, R r)
        {
            return new Res<O, R>()
            {
                value = o,
                result = r,
                succ = Equals(o, v),
            };
        }
        static public Res<O, R> Case<O, R>(this Res<O, R> o, Predicate<O> cond, R r)
        {
            if (!o.succ && cond(o.value))
            {
                o.result = r;
                o.succ = true;
            }
            return o;
        }
        static public Res<O, R> Case<O, R>(this O o, Predicate<O> cond, R r)
        {
            return new Res<O, R>()
            {
                value = o,
                result = r,
                succ = cond(o),
            };
        }
        private static bool Equals<O, V>(O o, V v)
        {
            return o == null ? v == null : o.Equals(v);
        }
        static public R Default<O, R>(this Res<O, R> o, R r)
        {
            return o.succ
                ? o.result
                : r;
        }
        static public R Default<O, R>(this Res<O, R> o, Func<O, R> def)
        {
            return o.succ ? o.result : def(o.value);
        }
    }
