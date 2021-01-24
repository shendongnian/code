    public class CustomServiceHost: ServiceHost, ISharedStateContainer
    {
       SharedState state;
       public SharedState State{ get{ return state; } set{ state=value; } }       
    }
