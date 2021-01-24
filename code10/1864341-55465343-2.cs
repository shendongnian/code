    [Route("api/[controller]")]
    [ApiController]
    public class SomeTypeController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public SomeTypeController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SomeTypeContract>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllSomeTypeRequest(), cancellationToken);
            return Ok(mapper.Map<IEnumerable<SomeTypeContract>>(result));
        }
    }
