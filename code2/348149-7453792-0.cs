    var o = Observable.Return(HttpWebRequest.Create("http://www.google.com"))
                      .SelectMany(r => Observable.FromAsyncPattern<WebResponse>(
                          r.BeginGetResponse,
                          r.EndGetResponse)())
                      .SelectMany(r =>
                      {
                          return Observable.Using( () => r, (resp) => Observable.Return(resp.ContentLength));
                      });
