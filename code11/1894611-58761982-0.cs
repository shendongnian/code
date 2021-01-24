            WebRequestHandler handler = new WebRequestHandler();
            handler.ClientCertificates.Add(cert);
            HttpClient client = new HttpClient(handler) { Timeout = Timeout.InfiniteTimeSpan };
            try {
                var httpResponse = await client.GetAsync(URL) as HttpResponseMessage;
                using (var remoteStream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (var content = File.Create(filepath)) {
                    var buffer = new byte[4096];
                    int read;
                    while ((read = await remoteStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) != 0) {
                        await content.WriteAsync(buffer, 0, read).ConfigureAwait(false);
                        FlushFileBuffers(content.SafeFileHandle);
                    }
                }
            } catch (Exception e) {
                //
            }
