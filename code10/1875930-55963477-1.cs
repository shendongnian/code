    public class Status : IEquatable<Status> {
      public int StatusID { get; set; }
      public string StatusString { get; set; }
      public Status(int statusID, string statusString) {
        StatusID = statusID;
        StatusString = statusString;
      }
      public override bool Equals(object obj) {
        if (obj.GetType() != GetType()) return false;
        return Equals(obj as Status);
      }
      public bool Equals(Status that) {
        return that != null && this.StatusID == that.StatusID;
      }
      public override int GetHashCode() {
        var hashCode = -1280899892;
        hashCode = hashCode * -1521134295 + StatusID.GetHashCode();
        return hashCode;
      }
    }
