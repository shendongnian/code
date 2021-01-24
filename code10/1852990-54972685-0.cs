                var webRequest = HttpWebRequest.Create(url);
                using (var webResponse = webRequest.GetResponse())
                {
                    var file_size = webResponse.Headers.Get("Content-Length");
                    var file_name = webResponse.ResponseUri.Segments.Last();
                }
