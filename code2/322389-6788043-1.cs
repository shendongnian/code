        public static string DoStuff<T,U,V,W>(Type objectType,
            Action<T> f, Action<U> g, Action<V> h, Action<W> i)
        {
            switch (objectType)
            {
                case ObjectType.UserReview:
                    return f();
                case ObjectType.ProfessionalReview:
                    return g();
                case ObjectType.Question:
                    return h();
                case ObjectType.News:
                    return i();
                default:
                    throw new ArgumentOutOfRangeException("objectType");
            }
        }
