    public class Channel
    {
     private Dictionary <int, string> ChannelLookup = 
     new Dictionary <int, string> ()
     {
      {1, new List<string>{"[A]","[B]","[C]"}},
      {2, new List<string>{"[A]"}
     };
    
     public string channelDisplay (int val)
     {
      if(!ChannelLookup.ContainsKey(val))
      {
        // throw exception
      }
      else
      {
        string display = string.Join(",", ChannelLookup[val]);
        return display;
      }
     }
    }
