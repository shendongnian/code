     [HttpGet]
     [CheckPermission("au")]
     public ActionResult<AppUser> UpdateUser([FromBody]AppUser au)
     {
            // focus on your business logic
     }
