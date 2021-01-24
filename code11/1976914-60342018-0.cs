    [HttpGet]
    [Route("SendPushNotification")]
        public IHttpActionResult SendPushNotification(string userId, string factorId, string domain)
        {
            var response = _oTPRepository.SendPushNotification(userId, factorId, domain);
    
            return Ok(response);
        }
