    public virtual Stream GetGroupById(string id)
    {
        var user = UserRepository.GetUserById(id);
        var dto = new Contracts.UserDto
                  {
                      Email = user.Email.ToString(),
                      Password = user.Password.ToString(),
                      UserId = user.UserId.ToString(),
                      UserName = user.UserName.ToString()
                  }
        var serializer = new JavaScriptSerializer()l
        var bytes = Encoding.UTF8.GetBytes(serializer.Serialize(dto));
        return new MemoryStream(bytes);
    }
