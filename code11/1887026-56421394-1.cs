    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using unirest_net.http;
    using unirest_net;
    namespace NBA_test
    {
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start ...");
            //the added Wait() causes the thread to hold until the task is finished.
            Task<HttpResponse<MyClass.RootObject>> response = Unirest.get("https://api-nba-v1.p.rapidapi.com/gameDetails/5162")
            .header("X-RapidAPI-Host", "api-nba-v1.p.rapidapi.com")
            .header("X-RapidAPI-Key", "myKey")
            .asJsonAsync<MyClass.RootObject>();
            
            
            //if need to perform other logic while you are waiting
            while(response.Status == TaskStatus.Running)
            {
             // perform other logic like gui here
            }
            var status = response.Status;
            Console.WriteLine("End ....");
        }
    }
    public class MyClass
    {
        public class Result
        {
            public string seasonYear { get; set; }
            public int gameId { get; set; }
            public string arena { get; set; }
        }
        public class RootObject
        {
            public List<Result> results { get; set; }
        }
    }
}
