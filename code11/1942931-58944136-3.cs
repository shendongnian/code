    public class UserManager : IUserManager
    {
        private IUserRepository _userRepository;
        private IAddressRepository _addressRepository;
        public UserManager(IUserRepository userRepository, 
           IAddressRepositoryaddressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }
        public bool ValidateUser(string userName, string password)
        {
            return _userRepository.ValidateUser(userName, password);
        }
        public void SaveUser(UserDTO userDTO, AddressDTO addressDTO)
        {
            try
            {
                // Is doesn't matter if you use _userRepository or _addressRepository,
                // because this classes use the same UnitOfWork.
                _userRepository.UnitOfWork.BeginTransaction();
                _userRepository.Add(ConvertToUser(userDTO));
                _addressRepository.Add(ConvertToAddress(addressDTO));
                _userRepository.UnitOfWork.SaveCahnges();
                _userRepository.UnitOfWork.Commit();
            }
            catch (Exception)
            {
                // Todo - log exception 
                _userRepository.UnitOfWork.Rollback();
            }
        }
    }
