            [HttpPost]
            [Route("sendF/{b}/{length}")]
            public HttpResponseMessage SendF([FromUri]byte[] b, [FromUri]int length)
            {
                if(length != 0)
                {
                    bytes.AddRange(b);                
                }
                else
                {
                    File.WriteAllBytes(@"G:\test\test.exe", bytes.ToArray<byte>());
                }
    
                return CreateResponse(client);
            }
