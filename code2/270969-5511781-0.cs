        public class TResult
        {
            public static  TResult Parse(string text)
            {
                //Parse here
                return new TResult();
            }
            public static bool TryParse(string text, out TResult mc)
            {
                try
                {
                    mc = Parse(text);
                    return true;
                }
                catch(Exception ex)
                {
                    mc = null;
                    return false;
                }
            }
        }
