    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Nancy.Json;
    
    namespace Training.Threading
    {
        class TasksDemo
        {
            static async Task Main(string[] args)
            {
                string json = await GetPostsAsync();
                // System.Console.WriteLine(json);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var posts = ser.Deserialize<Post[]>(json);
                
                foreach(Post post in posts)
                    System.Console.WriteLine(post.Title);
            }
    
            public static async Task<string> GetPostsAsync()
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(@"https://jsonplaceholder.typicode.com");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                    // You don't need await here
                    return await client.GetStringAsync("/posts");
                }
            }
        }
        public class Post
        {
            public int UserId { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
        }
    }
