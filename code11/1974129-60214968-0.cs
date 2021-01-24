static object SpinLock = new object();
lock(SpinLock)
{
   //Statements
}
In your case
hat I am trying to do is find a way to lock the static method so it can process 1 thread at a time so no matter how many simultaneous calls come in the static method runs synchronously. Here is basically the code I am calling. If this gets called twice at the same time they both return the same value, which is not what I want.
public static class Manager
{
  static object SpinLock = new object();
  // Remove the public or protect the get set with a lock
  static Dictionary<string, bool> ServerList { get; set; }
  static int NumberOfServers { get; set; }
  static int NextServerIndex { get; set; }
  public static string GetNextServer()
  {
     lock(SpinLock)
     {
   
        int indextocheck = NextServerIndex;
        string servername= null;
        if (indextocheck >= NumberOfServers)
          indextocheck = 0;
        while (timer < maxtime)
        {
          if (ServerList.Values.ElementAt(indextocheck) == false)
          {
            servername = ServerList.Keys.ElementAt(indextocheck);
            ServerList[server] = true;
            NextServerIndex = indextocheck + 1;
            break;
          }
          indextocheck++;
          if (indextocheck == NumberOfServers)
              indextocheck = 0;
          }
     }
    return servername;
  }
}
