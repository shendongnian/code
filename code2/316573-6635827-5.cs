    static class EventBus
    {
      public delegate void PublishObject(object sender, EventArgs args);
      private static List<PublishObject> subscribers = new List<PublishObject>();
      public static event PublishObject Publish
      {
         add
         {
            subscribers.Add(value);
            Console.WriteLine("Added subscriber {0}.{1}", value.Method.DeclaringType.Name, value.Method.Name);
         }
         remove
         {
            bool result = subscribers.Remove(value);
            Console.WriteLine("Removed subscriber {0}.{1} ({2})", value.Method.DeclaringType.Name, value.Method.Name, result ? "success" : "failure");
         }
      }
      // PublishEvent
      public static void Update(object sender, EventArgs args)
      {
         foreach (PublishObject p in subscribers)
         {
            Console.WriteLine("Publishing to {0}.{1}", p.Method.DeclaringType.Name, p.Method.Name);
            p.Invoke(sender, args);
         }
      }
      public static void UnsubcribeAll()
      {
         subscribers.Clear();
      }
    }
