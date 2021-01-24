        var message = new Message()
        {
            Token = token,
            Notification = new Notification()
            {
                Body = notificationBody,
                Title = title
            },
            Android = new AndroidConfig()
            {
                Priority = Priority.High
            },
            Webpush = new WebpushConfig()
            {
                FcmOptions = new WebpushFcmOptions()
                {
                     Link= "https://www.davnec.eu/aurora-boreale/previsioni/"
                }
            }
        };
