    <TestFixture()>
    Public Class UserServiceTest
    Private userRepository As Mock(Of IUserRepository)
    Public serviceUnderTest As IUserService
    <SetUp()>
    Public Sub SetUp()
        userRepository = New Mock(Of IUserRepository)(MockBehavior.Strict)
        serviceUnderTest = New UserService(userRepository.Object)
    End Sub
    
    <Test()>
    Public Sub Test_Edit()
        'Arrange
        Dim userDto As New UserDto With {.UserName = "gbrown", .UserPassword = "power", .Id = 98, .ProfileId = 1}
        Dim userObject As User = Nothing
        userRepository.Setup(Sub(x) x.Edit(It.IsAny(Of User))) _
        .Callback(Of User)(Sub(m) userObject = m)
        'Act
        serviceUnderTest.Edit(userDto)
        'Assert
        userRepository.Verify(Sub(x) x.Edit(It.IsAny(Of User)), Times.AtLeastOnce())
        Assert.NotNull(userObject)
        Assert.AreEqual(userDto.Id, userObject.Id)
        Assert.AreEqual(userDto.ProfileId, userObject.Profile.Id)
        Assert.AreEqual(userDto.UserName, userObject.UserName)
        Assert.AreEqual(userDto.UserPassword, userObject.UserPassword)
    End Sub
    End Class
