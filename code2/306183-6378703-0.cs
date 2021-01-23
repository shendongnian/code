Get("mykey", () => test(myparam))
        public static T Get<T>(string key, Func<T> method)
        {
            //do stuff
            var obj = method.Invoke();
            return (T)obj;
        }
        void Xyz()
        {
            int myparam = 0;
            var x = Get("mykey", () => test(myparam)); // <string> is not needed
        }
        double test(int i)
        {
            return 0.0;
        }
