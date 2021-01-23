        static T MyFunction<T>() {
            string s = "test";
            if (typeof(T) == typeof(byte[]))
                return (T)(object)System.Text.Encoding.ASCII.GetBytes(s);
            else if (typeof(T) == typeof(string))
                return (T)(object)s;
            else throw new Exception();
        }
...
                var ba = MyFunction<byte[]>();
                var bs = MyFunction<string>();
