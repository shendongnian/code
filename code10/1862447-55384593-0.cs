    public interface ISteering
    {
        float Steering {get; set;}
    }
    public class GeneticController : ISteering
    {
        public float Steering{ get; set; }
    }
    public class GeneticDriver: ISteering
    {
        public float Steering{ get; set; }
    }
