    [HttpPost]
    public async Task<IHttpActionResult> Process()
    {
        using (var requestStream = await Request.Content.ReadAsStreamAsync().ConfigureAwait(false))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MyEntity));
            MyEntity entity = serializer.Deserialize(requestStream) as MyEntity;
        }
        ...
    }
