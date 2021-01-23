        public static string DoStuff<T,U,V,W>(Type objectType,
            Func<T, string> f, Func<U, string> g, Func<V, string> h, Func<W, string> i)
        {
            object o=new object();
            switch (1)
            {
                case 1: //ObjectType.UserReview:
                    return f((T)o);
                case 2: //ObjectType.ProfessionalReview:
                    return g((U)o);
                case 3: //ObjectType.Question:
                    return h((V)o);
                case 4: //ObjectType.News:
                    return i((W)o);
                default:
                    throw new ArgumentOutOfRangeException("objectType");
            }
        }
