    abstract class ActiveRecord
    {
      protected virtual void OnNewItem() {}
    }
    
    class UserRecord : ActiveRecord
    {
    
      protected override void OnNewItem()
      {
        // Still got the UserRecord object, now it's just "this"
      }
    }
