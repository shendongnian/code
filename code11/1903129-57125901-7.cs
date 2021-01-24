        static void Main(string[] args)
        {
          // both Uri & Url u can get it from ur app.config or web.config to make it easier to edit on publish saves you alot of time.
           string Uri = "http://localhost:55587"; 
           string Url = "api/Student";
           string token = "yourtoken"; //(optional)
           ApiResult<Student> result = ApiResult<Student>.Get(Uri, "/" + Url, token);
            if(result.Success && result.List.Any())
           {
            IEnumerable<Student> list = result.List;
            return list;
           }
           else
           //return error if result.success is false else there are no records... 
        }
