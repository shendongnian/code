      [Route("Get/{transId}")]
        [HttpGet, HttpPost]
        public IHttpActionResult GetCountryResult(string transId)
        {
            Country data;
    
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    data = dbContext.Country
                        .Where(x => x.TransID.Equals(new Guid(transId)))
                        .FirstOrDefault();
                }
    
                return Ok(data);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
