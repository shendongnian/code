    public class EAccess : IAccess
        {
           private static EConnector Connector
            public EConnector getConnector(){
               if(Connector == null){
                   Connector = new EConnector();
                } 
                 return Connector;
            }
           public double Timestep(double time, double[] values)
            {
              return getConnector().Connect();
            }
    
        };
