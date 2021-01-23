     public class DataBindings : NinjectModule 
        { 
            public override void Load() 
            { 
                Bind<IReviewRepository>().To<ReviewRepository>(); 
                Bind<ReviewManager>().ToSelf();
            }  
        } 
