    public IAsyncResult BeginGetUser(AsyncCallback callback, object state)
    {
      var taskFunc = Task<DbReader>.Factory.FromAsync(db.BeginGetUser, db.EndGetUser);
      return taskFunc.ContinueWith(task => {
        var reader = task.Result;
        reader.Read();
        return new Data.User {
          DisplayName = reader["displayName"] as string,
          UserId = Guid.Parse(reader["userId"] as string),
        }
       }
      );
    }
    public Result<Data.User> EndGetUser(IAsyncResult asyncResult)
    {
      return (Task<User>)(asyncResult).Result;
    }
