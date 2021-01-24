 [Route("/alive")]
 [AllowAnonymous]
 [HttpGet]
 public string Alive()
 {
    return "I'm alive and loving it!";
 }
