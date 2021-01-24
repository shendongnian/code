    public abstract class AccesorioTransformador
    {
        public Guid Id { get; set; }
        public string CodigoAccesorio { get; set; }
        public int Cantidad { get; set; }   
    }
    
    public class AccesorioStepUp : AccesorioTransformador
    {
        public string CodigoDelfos { get; set; }
        public int Revision { get; set; }   
        [ForeignKey(nameof(CodigoDelfos)+","+nameof(Revision))]   
        public StepUp.StepUp Transformador { get; set; }
    }
    
    public class AccesorioDistribucion : AccesorioTransformador
    {
        public string CodigoDelfos { get; set; }
        public int Revision { get; set; }           
        [ForeignKey(nameof(CodigoDelfos) + "," + nameof(Revision))]
        public Transformador Transformador { get; set; }
    }
