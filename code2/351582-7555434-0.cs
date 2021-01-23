    Public Class UserService
    Implements IUserService
    Private ReadOnly userRepository As IUserRepository
    Public Sub New( _
       ByVal userRepository As IUserRepository)
        Me.userRepository = userRepository
    End Sub
    Public Sub Edit(userDto As Dtos.UserDto) Implements Core.Interfaces.Services.IUserService.Edit
        Try
            ValidateUserProperties(userDto)
            Dim user = CreateUserObject(userDto)
            userRepository.Edit(user)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Function CreateUserObject(userDto As Dtos.UserDto) As User Implements  Core.Interfaces.Services.IUserService.CreateUserObject
        Dim user = New User With {.Id = userDto.Id, _
                  .UserName = userDto.UserName, _
                  .UserPassword = userDto.UserPassword, _
                  .Profile = New Profile With {.Id = userDto.ProfileId}}
        Return user
    End Function
    Sub ValidateUserProperties(userDto As Dtos.UserDto)
       
    End Sub
