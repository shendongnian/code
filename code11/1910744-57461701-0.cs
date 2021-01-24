           public static bool Equals(object firstDouble, object secondDouble)
            {
                if((firstDouble.GetType() != typeof(int)) || (secondDouble.GetType() != typeof(int)))
                {
                    return false;
                }
                else
                {
                   return Math.Abs((int)firstDouble - (int)secondDouble) <= double.Epsilon;
                }
               
            }
