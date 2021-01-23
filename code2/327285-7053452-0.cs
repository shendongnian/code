    var container = new Container(x => {
                x.For<IAWebService>().Use<AWebService>()
                    .Ctor<string>("applicationId").Is("my app id")
                    .Ctor<string>("username").Is("my username")
                    .Ctor<string>("password").Is("my passowrd");
            });
