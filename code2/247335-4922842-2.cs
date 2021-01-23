        internal class ContextAwareInterceptor : EmptyInterceptor
        {
            public override void SetSession( ISession session )
            {
                if( AppInstance.Current == null )
                {
                    return;
                }
    
                // When a User is logged on, the CurrentUserContextFilter should be enabled.
                if( AppInstance.Current.CurrentUser != null )
                {
                    session.EnableFilter (AppInstance.CurrentUserContextFilter)
                                                .SetParameter (AppInstance.CurrentUserContextFilterParameter,
                                                               AppInstance.Current.CurrentUser.Id);
        
                }
            }
    }
