    public class HasGenericMethod
    {
        private string UnTrickyHelper<T>(T param){
            return ParameterLessGenericMethod<T>();
        }
    
        public string UnTrickyMethod(object param)
        {
            return UnTrickyHelper((dynamic)param);
        }
    }
