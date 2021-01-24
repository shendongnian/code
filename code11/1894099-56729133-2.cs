        public class ValuesController : ControllerBase
        {
            private readonly IMapper _mapper;
            public ValuesController(IMapper mapper)
            {
                _mapper = mapper;
            }
            // GET api/values
            [HttpGet]
            public ActionResult<IEnumerable<string>> Get()
            {
                PagedList<Caste> result = new PagedList<Caste>
                {
                    Items = new List<Caste> { new Caste { Id = 7, CasteCode = "" } },
                    TotalItems = 1
                };
                var pagedListOfDtos = _mapper.Map<PagedList<CasteModel>>(result);
                return new string[] { "value1", "value2" };
            }       
        }
 
