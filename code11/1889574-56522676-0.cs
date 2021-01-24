     public async Task<bool> AddAsync<T>(T dto) where T : IPassword
        
            {
                T data = _mapper.Map<T>(dto);
        
                data.PasswordHash = PBKDF2Hasher.HashPassword(data.Password);
        
                await _developerManager.Clients.AddAsync(data);
        
                return true;
            }
        
        public interface IPassword {
        string Password {set;get;}
        }
        
        public class EndUserServicesDTO : IPassword
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Role { get; set; }
            public string Password { get; set; }
            public string RetypePassword { get; set; }
        }
        
        public class AppDeveloperServicesDTO : EndUserServicesDTO, IPassword
        {
            public string CompanyName { get; set; }
            public string CompanyAdress { get; set; }
            public string CompanyEmail { get; set; }
            public string CompanyPhoneNumber { get; set; }
            public string CompanyWebSite { get; set; }
        }
