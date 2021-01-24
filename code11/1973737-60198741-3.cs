    public async Task MyTestMethod() {
        //Arrange
        Dictionary<string, HttpResponseMessage> messages = new Dictionary<string, HttpResponseMessage>();
        messages.Add("https://somesite1.com/ping", new HttpResponseMessage() {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("[{'id':'0001'," +
                                        "'name':'Jonah'," +
                                        "'street':'Cambridge Street 1234'}]"
                                        )
        });
        messages.Add("https://somesite2.com/ping", new HttpResponseMessage() {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("[{'id':'34'," +
                                        "'insurance':'Etx'," +
                                        "'insider':'daily'," +
                                        "'collectives':'4'}]"
                                        )
        });
        var client = new HttpClient(new TestMessageHandler(messages));
        //...inject client as needed
