                if (this._prog == null)
                {
    //                ObjectFactory.Initialize(x => x.PullConfigurationFromAppConfig = true);
                    ObjectFactory.Initialize(x => {
                    x.AddRegistry<MyRegistery>();
                    });
                }
