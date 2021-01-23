            var fb = new FacebookClient(_accessToken);
            var arguments = new Dictionary<string, object>();
            fb.PostCompleted += (o, args) =>
            {
                if (args.Error == null)
                    MessageBox.Show("Your status have been successfully posted to facebook!");
            };
            arguments["message"] = AboutTextBox.Text;
            fb.PostAsync("me/feed", arguments);
