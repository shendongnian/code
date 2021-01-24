    public class PersonalisationBogusService : IPersonalisationService {
        private readonly IMapToNew<Personalisation, PersonalisationState> _mapper;
    
    
        public PersonalisationBogusService(IPersonalisationToPersonalisationState mapper) {
            _mapper = mapper;
        }
    
        //...omitted for brevity
    }
