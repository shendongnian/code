    [Route("{username}/{password}/{latitude}/{longitude}/{depth}/{corporationId}")]
     public async Task<IHttpActionResult> Get(
     string username, 
     string password, 
     double latitude, 
     double longitude, 
     double depth, 
     int corporationId)
