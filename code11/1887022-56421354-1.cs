if (response.Code == 200) // Success, OK in HTTP Codes
{
  response.Body; // which body has the type of MyClass.RootObject
}
The complete example:
        public static void Main(string[] args)
        {
            Console.WriteLine("Start ...");
            HttpResponse<MyClass.RootObject> response = Unirest.get("https://api-nba-v1.p.rapidapi.com/gameDetails/5162")
            .header("X-RapidAPI-Host", "api-nba-v1.p.rapidapi.com")
            .header("X-RapidAPI-Key", "myKey")
            .asJson<MyClass.RootObject>();
            if (response.Code == 200) // Success, OK in HTTP Codes
            {
              response.Body; // which body has the type of MyClass.RootObject
            }
            Console.WriteLine("End ....");
            Console.ReadLine(); // to force command line stay up for an input and not close applicaiton immediately aftter runing it.
        }
  [1]: http://unirest.io/net.html
