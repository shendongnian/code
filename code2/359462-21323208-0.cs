    public static class TypedTuple
    {
        public static TypedTuple<T1> Create<T1>(T1 t1)
        {
            return new TypedTuple<T1>(t1);
        }
        public static TypedTuple<T1, T2> Create<T1, T2>(T1 t1, T2 t2)
        {
            return new TypedTuple<T1, T2>(t1, t2);
        }
        public static TypedTuple<T1, T2, T3> Create<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
        {
            return new TypedTuple<T1, T2, T3>(t1, t2, t3);
        }
        public static TypedTuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return new TypedTuple<T1, T2, T3, T4>(t1, t2, t3, t4);
        }
        public static TypedTuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return new TypedTuple<T1, T2, T3, T4, T5>(t1, t2, t3, t4, t5);
        }
        public static TypedTuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            return new TypedTuple<T1, T2, T3, T4, T5, T6>(t1, t2, t3, t4, t5, t6);
        }
        public static TypedTuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            return new TypedTuple<T1, T2, T3, T4, T5, T6, T7>(t1, t2, t3, t4, t5, t6, t7);
        }
        public static TypedTuple<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            return new TypedTuple<T1, T2, T3, T4, T5, T6, T7, T8>(t1, t2, t3, t4, t5, t6, t7, t8);
        }
    }
    public class TypedTuple<T>
    {
        public TypedTuple(T item1)
        {
            Item1 = item1;
        }
        public TSource Get<TSource>()
        {
            if (Item1 is TSource)
                return Get<TSource>(this.Item1);
            else
                return default(TSource);
        }
        protected TSource Get<TSource>(object item)
        {
            Type t = typeof(TSource);
            Type u = Nullable.GetUnderlyingType(t);
            if (u != null)
            {
                if (item == null)
                    return default(TSource);
                return (TSource)Convert.ChangeType(item, u);
            }
            else
            {
                return (TSource)Convert.ChangeType(item, t);
            }
        }
        public T Item1 { get; set; }
    }
    public class TypedTuple<T1, T2> : TypedTuple<T1>
    {
        public TypedTuple(T1 item1, T2 item2)
            : base(item1)
        {
            Item2 = item2;
        }
        public new TSource Get<TSource>()
        {
            if (Item2 is TSource)
                return Get<TSource>(this.Item2);
            else
                return base.Get<TSource>();
        }
        public T2 Item2 { get; set; }
    }
    public class TypedTuple<T1, T2, T3> : TypedTuple<T1, T2>
    {
        public TypedTuple(T1 item1, T2 item2, T3 item3)
            : base(item1, item2)
        {
            Item3 = item3;
        }
        public new TSource Get<TSource>()
        {
            if (Item3 is TSource)
                return Get<TSource>(this.Item3);
            else
                return base.Get<TSource>();
        }
        public T3 Item3 { get; set; }
    }
    public class TypedTuple<T1, T2, T3, T4> : TypedTuple<T1, T2, T3>
    {
        public TypedTuple(T1 item1, T2 item2, T3 item3, T4 item4)
            : base(item1, item2, item3)
        {
            Item4 = item4;
        }
        public new TSource Get<TSource>()
        {
            if (Item4 is TSource)
                return Get<TSource>(this.Item4);
            else
                return base.Get<TSource>();
        }
        public T4 Item4 { get; set; }
    }
    public class TypedTuple<T1, T2, T3, T4, T5> : TypedTuple<T1, T2, T3, T4>
    {
        public TypedTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
            : base(item1, item2, item3, item4)
        {
            Item5 = item5;
        }
        public new TSource Get<TSource>()
        {
            if (Item5 is TSource)
                return Get<TSource>(this.Item5);
            else
                return base.Get<TSource>();
        }
        public T5 Item5 { get; set; }
    }
    public class TypedTuple<T1, T2, T3, T4, T5, T6> : TypedTuple<T1, T2, T3, T4, T5>
    {
        public TypedTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
            : base(item1, item2, item3, item4, item5)
        {
            Item6 = item6;
        }
        public new TSource Get<TSource>()
        {
            if (Item6 is TSource)
                return Get<TSource>(this.Item6);
            else
                return base.Get<TSource>();
        }
        public T6 Item6 { get; set; }
    }
    public class TypedTuple<T1, T2, T3, T4, T5, T6, T7> : TypedTuple<T1, T2, T3, T4, T5, T6>
    {
        public TypedTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
            : base(item1, item2, item3, item4, item5, item6)
        {
            Item7 = item7;
        }
        public new TSource Get<TSource>()
        {
            if (Item7 is TSource)
                return Get<TSource>(this.Item7);
            else
                return base.Get<TSource>();
        }
        public T7 Item7 { get; set; }
    }
    public class TypedTuple<T1, T2, T3, T4, T5, T6, T7, T8> : TypedTuple<T1, T2, T3, T4, T5, T6, T7>
    {
        public TypedTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
            : base(item1, item2, item3, item4, item5, item6, item7)
        {
            Item8 = item8;
        }
        public new TSource Get<TSource>()
        {
            if (Item8 is TSource)
                return Get<TSource>(this.Item8);
            else
                return base.Get<TSource>();
        }
        public T8 Item8 { get; set; }
    }
