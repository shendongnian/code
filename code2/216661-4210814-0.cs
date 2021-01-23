    public class MyTicket {
      ...
      public string ToSerializableFormat() {
        return String.Format("{0}|{1}", t.Username, t.somethingElseYouNeed);
      }
      public static MyTicket Parse(string value) {
        var vals = value.Split('|');
        return MyTicket(values[0], values[1]);
      }
    }
