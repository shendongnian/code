csharp
ConcurrentQueue<string> UsersQueue;
public string getUsername()
{
   string user = null;
   UsersQueue.TryDequeue(out user);
   return user;
}
