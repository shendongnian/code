        [HttpPost]
        [Route("~/api/mypath/")]
        [ResponseType(typeof(ImageInfo))]
        public IHttpActionResult returnError([FromBody]StringModel value)
        {
           return Content(HttpStatusCode.Forbidden,"bla bla bla");
        }
    }
