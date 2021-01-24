    [Route("api/v1/camera/live/stream")]
        [HttpGet]
        public HttpResponseMessage GetStream()
        {
            logger.Trace($"GET api/v1/camera/live/stream called");
            
            var response = Request.CreateResponse(HttpStatusCode.PartialContent);
            response.Content = new PushStreamContent(new Action<Stream, HttpContent, TransportContext>(async (stream, content, tansportContext) =>
            {
                EventHandler<AcquiredDataEventArgs<CameraFrame>> handler = (_, __) => { };
                try
                {
                    MjpegWriter writer = new MjpegWriter(stream);
                    handler = (s, e) => writer.Write(e.Data.Image.GetJpegStream());
                   
                    camera.DataAcquired += handler;
                    while (HttpContext.Current.Response.IsClientConnected)
                    {
                        await Task.Delay(100);
                    }
                    camera.DataAcquired -= handler;
                   
                }
                catch (Exception ex)
                {
                    logger.Error($"Streaming error", ex);
                    throw;
                }
                logger.Trace("streaming ended");
            }));
            response.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/x-mixed-replace; boundary=--boundary");
            return response;
        }
