                string id = "my_request";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Accept = "*/*";
                request.AllowAutoRedirect = true;
                // disable caching.
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["Pragma"] = "no-cache";
                t = new Timer(
                    state =>
                    {
                        if (string.Compare(state.ToString(), id, StringComparison.InvariantCultureIgnoreCase) == 0)
                        {
                            logger.Write("Timeout reached for connection [{0}], aborting download.", id);
                            request.Abort();
                            t.Dispose();
                        }
                    },
                    id,
                    timeout * 1000,
                    0);
                request.BeginGetResponse(
                    r =>
                    {
                        try
                        {
                            if (t != null)
                            {
                                t.Dispose();
                            }
                    // more code
