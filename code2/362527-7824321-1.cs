    class Request<T> where T : new() 
    {
        private T sw; 
        public Request()
        {
            sw = new T();
        }
     }
