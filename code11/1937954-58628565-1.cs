    public class ProfileTest : AuthTest
    {
        [Theory, Priority(0)]
        [Roles(Enums.Role.SuperUser, Enums.Role.Editor)]
        public void OpenProfilePageTest(Enums.Role role)
        {
            AuthRepository.Login(role);
            var profile = GetPage<ProfilePage>();
            profile.GoTo();
            profile.IsAt();
        }
    }
