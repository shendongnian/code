     [HttpPost]
        public ActionResult<Blub> PostBlub([FromBody] APIRequest request)
        {
            return new Blub(request.Paths);
        }
        
        public class APIRequest
        {
            public string[] Paths { get; set; }
        }
