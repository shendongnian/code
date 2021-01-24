        public class Response
        {
            public RootObject data { get; set; }
        }
    ... and then:
        JsonConvert.DeserializeObject<Response>(json);
 
