    namespace userpanel {
        public class Jobs : PageModel {
            public UserManager<ApplicationUser> _userManager;
            public Jobs(UserManager<ApplicationUser> userManager) {
                _userManager = userManager;
            }
            public async Task<bool> UpdateUsers() {
                await using var conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=Old;Username=postgres;Password=123456");
                await conn.OpenAsync();
    
                //
                // 1. Download old users and create Identity versions
                //
                await using (var cmd = new NpgsqlCommand("SELECT * FROM public.old_users ORDER BY id;", conn))
                await using (var reader = await cmd.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync()) {
                        string providedOldId = reader.GetInt32(0).ToString();
                        string providedEmail = reader.GetString(2);
                        bool? providedIsAdmin = reader.GetBoolean(6);
                        string providedPassword = "123456";
                        await CreateUser(providedEmail, providedPassword, providedOldId, providedIsAdmin);
                    }
                }
                await conn.CloseAsync();
                return true;
                // ...
            }
            public async Task CreateUser(string providedEmail, string providedPassword, string providedOldId, bool?     providedIsAdmin) {
                bool IsAdmin = providedIsAdmin.HasValue != false;
                var user = new ApplicationUser {
                    UserName = providedEmail,
                    Email = providedEmail,
                    EmailConfirmed = true,
                    UserOldEmail = providedEmail,
                    UserOldId = providedOldId,
                    IsPaymentRequired = true,
                    IsAdministrator = IsAdmin,
                    Currency = 0.00
                    };
                await _userManager.CreateAsync(user, providedPassword);
            }
        }
    }
