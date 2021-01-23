      class MyBindings : NinjectModule
            {
                public override void Load()
                {
                    Bind<IMediaPresenter>().To<MediaPresenter>;
                    Bind<IDao>().To<Dao>();
                    Bind<IBook>().To<Book>();
                }
            }
