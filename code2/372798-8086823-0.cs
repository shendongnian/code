    public class HasGenericMethod
    {
        private string UnTrickyHelper<T>(T param){
            return ParameterLessGenericMethod<T>();
        }
    
        public string UnTrickyMethod(dynamic param)
        {
            return UnTrickyHelper(param);
        }
    }
