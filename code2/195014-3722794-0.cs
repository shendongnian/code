    class User : IMember {} 
    class Group : IMember {}
    class Resource : IResource {}
    // Assumes the User is already Authenticated in some way...
    class Authorisation
    {
        static bool IsAuthorised(IMember member, IResource resource) {}
        static bool IsDenied(IMember member, IResource resource) {}
        static bool IsAnyDenied(IEnumerable<IMember> members, IResource resource) {}
        static bool IsAnyAuthorised(IEnumerable<IMember> members, IResource resource) {}
    }
    class System
    {
        bool CanEnterAdminArea(User user, IResource admin) 
        {
            IEnumerable<Group> groups = u.Groups;
            if ( Authorisation.IsAnyDenied( groups, admin ) { return false; }
            if ( Authorisation.IsDenied( user, admin ) { return false; }
            return (Authorisation.IsAuthorised( user, admin ) 
                 || Authorisation.IsAnyAuthorised( groups, admin ));
            
            
        } 
    }
