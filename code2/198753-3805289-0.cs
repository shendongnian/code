    public class HasManagedMembers : IDisposable
    {
       /* more stuff here */
       public void Dispose()
       {
          //if really necessary, block multiple calls by storing a boolean, but generally this won't be needed.
          someMember.Dispose(); /*etc.*/
       }
    }
