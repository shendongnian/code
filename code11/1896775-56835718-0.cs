public interface IMyUserManager
{
    Task<bool> CheckPasswordAsync(User user, string oldPassword);
    Task<string> GeneratePasswordResetTokenAsync(User user);        
    Task<IdentityResult> ResetPasswordAsync(User user, string token, string 
        newPassword);
    }
}
Secondly, implement this interface with built-it UserManager<User>
public class MyUserManager : IMyUserManager 
{
    private readonly UserManager<User> _userManager;
    public MyUserManager(UserManager<User> userManager)
    {
        if (userManager is null)
        {
           throw new ArgumentNullException(nameof(userManager));
        }
        _userManager = userManager;
    }
    public Task<bool> CheckPasswordAsync(User user, string oldPassword)
    {
        return _userManager.CheckPasswordAsync(user, oldPassword);
    }
    public Task<string> GeneratePasswordResetTokenAsync(User user)
    {
        return _userManager.GeneratePasswordResetTokenAsync(user);
    }
    public Task<IdentityResult> ResetPasswordAsync(User user, string token, 
        string newPassword)
    {
        return _userManager.ResetPasswordAsync(user, token, newPassword);
    }
}
Then, rewrite your service
        private readonly IMyUserManager _userManager;
        public MyService(IMyUserManager userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> TryChangePassword(User user, string OldPassword, string NewPassword)
        {
            // it returns false
            var checkOldPassword = await _userManager.CheckPasswordAsync(user, OldPassword);
            if (!checkOldPassword)
            {
                return false;
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, NewPassword);
            return result.Succeeded;
Finally, write test cases as simple as possible. People around you never want to go to the implementation of subclasses when fix tests
[Fact]
        public async Task password_change_attempt_1()
        {
            var mock = new Mock<IMyUserManager>();
            MyService myService = new MyService(mock.Object);
            mock.Setup(x => x.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));
            mock.Setup(x => x.ResetPasswordAsync(It.IsAny<User>(), It.IsAny<string>(),
                It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Success));
            var result =
                await myService
                    .TryChangePassword(new User { Name = "Name", }, "OldPassword", "NewPassword");
            Assert.Equal(result, true);
        }
