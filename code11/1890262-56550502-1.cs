        [HttpPost]
        [Route("~/api/mypath/")]
        public IHttpActionResult returnError([FromBody]StringModel value)
        {
           return Content(HttpStatusCode.Forbidden,"bla bla bla");
        }
    }
