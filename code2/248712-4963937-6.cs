    public class SingleSessionPerUserManager : ServiceAuthorizationManager
    {
        private SessionStorage Storage { get; set; }
    
        public SingleSessionPerUserManager()
        {
            Storage = new SessionStorage();
        }
    
        protected override bool CheckAccessCore( OperationContext operationContext )
        {
            string name = operationContext.ServiceSecurityContext.PrimaryIdentity.Name;
            if ( Storage.IsActive( name ) )
                return false;
    
            Storage.Activate( operationContext.SessionId, name );
            operationContext.Channel.Closed += new EventHandler( Channel_Closed );
            return true;
        }
    
        private void Channel_Closed( object sender, EventArgs e )
        {
            Storage.Deactivate( ( sender as IContextChannel ).SessionId );
        }
    }
