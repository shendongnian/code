      _userRepository
        .Setup(u => u.DeleteAsync(It.IsAny<string>()))
        .Returns((string id) =>
          {
              var user = _userList.Find(p => p.Id == id);
              if (user != null)
                  _userList.Remove(user);
    
              return Task.CompletedTask;
          });  
