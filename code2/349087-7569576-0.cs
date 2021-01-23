    if (CanvasAuthorizer.Authorize())
            {
                var fb = new FacebookWebClient();
                dynamic parameters = new ExpandoObject();
                parameters.message = txtMessage.Text;
                try
                {
                    dynamic id = fb.Post("me/feed", parameters);
                    lblPostMessageResult.Text = "Message posted successfully";
                    txtMessage.Text = string.Empty;
                    //get post id
                    IDictionary<string, object> data = new Dictionary<string, object>();
                    data.Add("access_token", CanvasAuthorizer.FacebookWebRequest.AccessToken);
                    dynamic thePost = fb.Get(String.Format("{0}", id.id), data);
                    string post = String.Format("Post:{0} From: {1} Message: {2}", thePost.id, thePost.from.name, thePost.message);
                    lblPostMessageResult.Text = Environment.NewLine + post;
                }
                catch (FacebookApiException ex)
                {
                    lblPostMessageResult.Text = ex.Message;
                }
            }
