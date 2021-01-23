    public class UserManager
    {
        private string _domainName;
        private Dictionary<string, User> _userLookup;
        private PrincipalContext domainContext;
        private DirectoryEntry LDAPdirectory;
        public UserManager(string domainName)
        {
            _domainName = domainName;
            _userLookup = new Dictionary<string, User>();
            domainContext = new PrincipalContext(ContextType.Domain, _domainName);
            //Make the LDAP directory look for all users within the domain. DC Com, Au for australia
            LDAPdirectory = new DirectoryEntry("LDAP://DC=" + _domainName.ToLower() + ",DC=com,DC=au");
            LDAPdirectory.AuthenticationType = AuthenticationTypes.Secure;
        }
        public IEnumerable<User> Users
        {
            get
            {
                return _userLookup.Values.ToArray<User>();
            }
            set
            {
                _userLookup.Clear();
                foreach (var user in value)
                {
                    if (!_userLookup.ContainsKey(user.Login))
                        _userLookup.Add(user.Login, user);
                }
            }
        }
        /// <summary>
        /// Gets all the users from the AD domain and adds them to the Users property. Returns the list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> UpdateAllUsers()
        {
            DirectorySearcher searcher = new DirectorySearcher(LDAPdirectory);
            searcher.Filter = "(&(&(objectClass=user)(objectClass=person)(!objectClass=computer)(objectClass=organizationalPerson)(memberof=*)(telephonenumber=*)))";
            SearchResultCollection src = searcher.FindAll();
            _userLookup.Clear();
            foreach (SearchResult result in src)
            {
                User newUser = new User(domainContext, result.Properties["samaccountname"][0].ToString());
                if (newUser.IsInitialized)
                {
                    _userLookup.Add(newUser.Login, newUser);
                    yield return newUser;
                }
            }
           
        }
        public User GetUser(string userLogin)
        {
            return new User(domainContext, userLogin);
        }
        public bool HasUser(string login)
        {
            return _userLookup.ContainsKey(login);
        }
    }
    public class User
    {
        public User()
        {
            IsInitialized = false;
        }
        /// <summary>
        /// Initializes a new user based on the AD info stored in the domain    
        /// </summary>
        /// <param name="domainContext">The domain to search for this user</param>
        /// <param name="userName">The user to look for</param>
        public User(PrincipalContext domainContext, string userName)
        {
            try
            {
                using (UserPrincipal thisUserPrincipal = UserPrincipal.FindByIdentity(domainContext, userName))
                {
                    this.FirstName = thisUserPrincipal.GivenName;
                    this.Surname = thisUserPrincipal.Surname;
                    this.DisplayName = thisUserPrincipal.DisplayName;
                    this.Email = thisUserPrincipal.EmailAddress;
                    this.ContactNumber = thisUserPrincipal.VoiceTelephoneNumber;
                    this.Login = thisUserPrincipal.SamAccountName;
                    IsInitialized = true;
                }
            }
            catch (Exception)
            {
                IsInitialized = false;
                return;
            }
        }
        /// <summary>
        /// Gets a value determining if this user was properly initialized or if an exception was thrown during creation
        /// </summary>
        public bool IsInitialized { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string ContactNumber { get; set; }
    }
