    class Request<T> where T : new() 
    {
        private T sw; 
        public Request()
        {
            //How can i create here the instance like
            sw = new T();
        }
     }
