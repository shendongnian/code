    public class CreatureController : Controller {
    
       private readonly ICreatureFactory _factory;
       public CreatureController(ICreatureFactory factory) {
         _factory = factory;
       }
       public HttpResponseMessage TurnToStone(string creatureType) {
           ICreature creature = _factory.GetCreature(creatureType);
       
           creature.TurnToStone();
           return Request.CreateResponse(HttpStatusCode.OK);
       }
    }
