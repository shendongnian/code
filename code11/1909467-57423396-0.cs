c#
        public async Task<IActionResult> OnPutAsync([FromForm] UserViewModel userViewModel)
        {
            try
            {
                await _user.InitializeAsync(userViewModel.Id);
                var user = _mapper.Map(userViewModel, _user);
                var (Succeeded, ErrorMessage) = await user.SaveAsync();
                return new JsonResult(new AjaxResultHelper<string>(Succeeded)
                {
                    Response = ErrorMessage ?? ResponseMessages.DataSaved
                });
            }
            catch (Exception ex)
            {
                // Need to log the error
                Console.WriteLine(ex.Message);
                return new JsonResult(new AjaxResultHelper<string>()
                {
                    Response = ResponseMessages.DataNotSaved
                });
            }
        }
**User Business:**
c#
    public class User : CoreEntityBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public User()
        {
        }
        public User(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public string Name { get; set; }
        [Sortable(Default = true)]
        [SearchableString]
        public string FirstName { get; set; }
        [Sortable]
        [SearchableString]
        public string LastName { get; set; }
        [Sortable]
        [SearchableString]
        public string Designation { get; set; }
        [Sortable]
        [SearchableString]
        public string IdentityNumber { get; set; }
        public Guid ProfileId { get; set; }
        [NestedSortable]
        [NestedSearchable]
        public Profile Profile { get; set; }
        public async Task InitializeAsync(Guid Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException($"{nameof(Id)} cannot be null");
            }
            var userEntity = await _userRepository.GetUserByIdAsync(Id);
            _mapper.Map(userEntity, this);
        }
        public async Task<PagedResults<User>> GetUsersAsync(
            PagingOptions pagingOptions,
            SortOptions<User, UserEntity> sortOptions,
            SearchOptions<User, UserEntity> searchOptions,
            CancellationToken ct)
        {
            var users = await _userRepository.GetUsersAsync(pagingOptions, sortOptions, searchOptions, ct);
            return new PagedResults<User>
            {
                Items = _mapper.Map<User[]>(users.Items),
                TotalSize = users.TotalSize
            };
        }
        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(userId);
            return _mapper.Map<User>(userEntity);
        }
        public async Task<(bool Succeeded, string ErrorMessage)> SaveAsync()
        {
            if (!Validate())
            {
                return (false, Error);
            }
            var userEntity = await _userRepository.GetUserByIdAsync(Id);
            userEntity = _mapper.Map(this, userEntity);
            var update = await _userRepository.UpdateUserAsync(userEntity);
            return update;
        }
        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                Error = "FirstName cannot be empty";
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(LastName))
            {
                Error = "LastName cannot be empty";
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(Designation))
            {
                Error = "Designation cannot be empty";
                isValid = false;
            }
            return isValid;
        }
    }
**User Repository:**
c#
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserEntity> _userManager;
        public UserRepository(
            UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserEntity> GetUserByIdAsync(Guid userId)
        {
            var entity = await _userManager.FindByIdAsync(userId.ToString());
            return entity;
        }
        public async Task<(bool Succeeded, string ErrorMessage)> UpdateUserAsync(UserEntity userEntity)
        {
            var result = await _userManager.UpdateAsync(userEntity);
            if (result.Succeeded)
            {
                return (true, null);
            }
            var firstError = result.Errors.FirstOrDefault()?.Description;
            return (false, firstError);
        }
    }
