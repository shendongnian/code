    .....
    using Google.Apis.Blogger.v3.Data;
    .....    
    
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync("https://www.googleapis.com/blogger/v3/blogs/<blogkey>/posts?key=<mykey>");          
        // Get all posts (typed as PostList) from blog.
        var postList = JsonConvert.DeserializeObject<PostList>(response.Content.ReadAsStringAsync().Result);
    }
