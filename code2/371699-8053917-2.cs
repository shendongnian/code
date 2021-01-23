         private bool TestAdShouldChangePassword( string adUser )
         {
                        try
                        {
                            string adName = "";
                            MembershipUser mu = Membership.GetUser( adUser );
            
                            if ( mu != null )
                            {
                                IStudentPortalLoginBLL splBll = ObjectFactory.GetInstance< IStudentPortalLoginBLL >();
                                adName = splBll.GetCleanAdName( adUser );// I wrote this is just pulls outhe name and fixes the caplitalization - EWB
            
                                PrincipalContext pctx = new PrincipalContext( System.DirectoryServices.AccountManagement.ContextType.Domain );
                                UserPrincipal p = UserPrincipal.FindByIdentity( pctx, adName );
            
                                if ( p == null )
                                    return false;
            
                                if ( p.LastPasswordSet.HasValue == false && p.PasswordNeverExpires == false )
                                {
                                    return true;
                                }
                            }
                        }
                        catch ( MultipleMatchesException mmex )
                        {
                            log.Error ( "TestAdShouldChangePassword( ad user = '" + adUser + "' ) - Exception finding user, can't determine if ad says to change password, returing false : Ex = " + mmex.ToString() );
                        }
            
                        return false;
          }
