    [HttpPost]
    [Produces("application/xml")]      
    public async Task<IActionResult> PostReceivedMessage([FromForm]string receivedMessage)
        {
           
            XmlSerializer serializer = new XmlSerializer(typeof(ReceivedMessage));
            ReceivedMessage data;
            using (TextReader reader = new StringReader(receivedMessage))
            {
                 data = (BaseClass)serializer.Deserialize(reader);
            }
            
           
            return Ok(data);
        }
