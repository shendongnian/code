    [Route("/foo/{Bar}", "POST")]
    public class PostFooRequest : IReturn<PostFooResponse>
    {
        public string Bar { get; set; }
    
        public int Qux { get; set; }
        public string Corge { get; set; }
    }
