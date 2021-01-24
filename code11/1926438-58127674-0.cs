    1.public static object DBNullValueorIntIfNotNull(int value)
        {
            object o;
            if (value <= 0)
            {
                o = 0;
            }
            else
            {
                o = value;
            }
            return o;
        }
