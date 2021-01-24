        [HttpPost]
        [Route("api/forge/callback/webhookbysig")]
        public async Task<IActionResult> WebhookCallbackBySig()
        {
            try
            {
                var encoding = Encoding.UTF8;
                byte[] rawBody = null;
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    rawBody = encoding.GetBytes(reader.ReadToEnd());
                }
                var requestSignature = Request.Headers["x-adsk-signature"];
                string myPrivateToken = Credentials.GetAppSetting("FORGE_WEBHOOK_PRIVATE_TOKEN");
                var tokenBytes = encoding.GetBytes(myPrivateToken);
                var hmacSha1 = new HMACSHA1(tokenBytes);
                byte[] hashmessage = hmacSha1.ComputeHash(rawBody);
                var calculatedSignature = "sha1hash=" + BitConverter.ToString(hashmessage).ToLower().Replace("-", "");
                if (requestSignature.Equals(calculatedSignature))
                {
                    System.Diagnostics.Debug.Write("Same!");
                }
                else
                {
                    System.Diagnostics.Debug.Write("diff!");
                }
            }
            catch(Exception ex)
            {
            }
            // ALWAYS return ok (200)
 
            return Ok();        
     }
