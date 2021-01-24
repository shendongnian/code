    public class ProfileTest : AuthTest {
        [Theory, Priority(0)]
        [InlineData(Enums.Role.SuperUser)]
        [InlineData(Enums.Role.Editor)]
        public void OpenProfilePageTest(Enums.Role role) {
            //Arrange
            AuthRepository.Login(role);            
            var profile = GetPage<ProfilePage>();
            
            //Act
            profile.GoTo();
            
            /?Assert
            profile.IsAt();
        }
    }
