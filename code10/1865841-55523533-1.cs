    public class SomeProductController : BaseProductController<SomeProduct, SomeProductModel>
    {
        public SomeProductController(ApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
