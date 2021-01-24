    public class EmailManager : IEmailManager
    {
        public async Task<Dictionary<string, string>> GetAdminEmails(UserManager<ApplicationUser> userManager)
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();
            foreach (var email in userManager.Users.ToList())
            {
                var user = await userManager.FindByEmailAsync(email.Email);
                var roles = await userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    if (role == "Admin")
                    {
                        emails.Add(email.Email, email.Id);
                    }
                }
            }
            return emails;
        }
    }
