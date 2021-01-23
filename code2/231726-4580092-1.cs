    class Json
    {
        private Json(string json)
        {
            //logic to parse string into object
        }
    
        public static implicit operator Json(string input)
        {
            return new Json(input);
        }
    }
