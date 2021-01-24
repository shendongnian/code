        [HttpGet("{value}")]
        [Produces("application/xml")]
        public IActionResult GetXml(string value)
        {
            var xml = $"<result><value>{value}</value></result>";
            //HttpResponseMessage response = new HttpResponseMessage();
            //response.Content = new StringContent(xml, Encoding.UTF8);
            //return response;
            
            return new ContentResult{
                ContentType = "application/xml",
                Content = xml,
                StatusCode = 200
            };
        }
