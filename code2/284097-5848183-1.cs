    //  Maps to just String, but you could create and return whatever types you require...
    public static class ExceptionProcessor {
        static Dictionary<System.Type, Func<String, Exception> sExDictionary = 
         new Dictionary<System.Type, Func<String, Exception> {
            { 
                typeof(System.Exception), _ => {
                    return _.GetType().ToString();
                }
            },
            { 
                typeof(CustomException), _ => { 
                    CustomException tTmp = (CustomException)_; 
                    return tTmp.GetType().ToString() + tTmp.CustomMessage; 
                }
            }
        }
    
        public System.String GetInfo(System.Exception pEx) {
            return sExDictionary[pEx.GetType()](pEx);
        }
    }
