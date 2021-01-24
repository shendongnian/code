     [HttpPost]
     [Route("Upload")]
     public void Upload()
     {
            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
           //In that case, you could iterate over your dictionary or you can access values directly:
            var CurrentContext = dict["example"];
      }
