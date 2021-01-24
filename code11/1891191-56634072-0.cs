    using Nito.AsyncEx;
    [WebMethod]
        public static string CheckImage(string image)
        {
            var result =  AsyncContext.Run(() => MyAsyncMethod(image));           
            return result; 
        }
        private static async Task<string> MyAsyncMethod(string image)
        {
            //do async stuff
        }
