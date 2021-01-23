    public class DifferentClassLibrary
    {
    	public delegate void StringDataDelegate(string data);
        public event StringDataDelegate UpdatedData;
        public void DoStuff()
        {
            if (UpdatedData != null)
            {
                Thread.Sleep(10000);
                UpdatedData("data");
            }
        }
    }
