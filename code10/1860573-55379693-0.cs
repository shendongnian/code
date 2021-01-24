        [HttpPut]
        public HttpResponseMessage Put(int id, Product product)
        {
            //save the Product object.
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }
