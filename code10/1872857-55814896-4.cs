    public class CardController : Controller
    {
    private readonly IMapper;
    public CardController(IMapper mapper)
    {
    _mapper = mapper;
    }
    [HttpGet]
    [Route("api/v1/cards")]
    public IActionResult Cards(inputParameters,selector,filtering)
    {
    var result = DoYourThing();
    
    //if a list of cards
    if(result != null && result.Count > 0) return Ok(_mapper.Map<List<Card>, List<CardViewModel>>(result));
    return NoContent();
    
    // if single card object
    if(result != null) return Ok(_mapper.Map<Card, CardViewModel>())
    return NoContent();
    }
    
    }
