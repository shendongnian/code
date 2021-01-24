    public class MyController : BaseController
    {
            private readonly MyOtherParam;
    
            public MyController (IMapper mapper, OtherClassType myOtherParam)
               :base(mapper)
            {
                this.MyOtherParam= myOtherParam;
            }
    }
