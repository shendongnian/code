            public bool isComparable<t>(object o)
            {
                try
                {
                    object r = (t)o;
                }
                catch
                {
                    return false;
                }
                return true;
            }
