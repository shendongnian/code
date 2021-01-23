     public static void GetStreamFromUri(Uri uri, Action<Stream> returnResult)
     {
          WebClient client = new WebClient();
          client.OpenReadCompleted += (s, args) =>
          {
               returnResult(args.Result);
          };
          client.OpenReadAsync(uri);
     }
