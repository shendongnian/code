    class Program
    {
      static void Main(string[] args)
      {
         BusinessObject1 bo = new BusinessObject1("First Value");
         // Subscribe
         EventBus.Publish += new EventBus.PublishObject(EventBus_Publish);
         bo.Update("Second Value");
         // UnSubscribe
         EventBus.Publish -= new EventBus.PublishObject(EventBus_Publish);
         bo.Update("Third Value");
         // Subscribe multiple
         EventBus.Publish += new EventBus.PublishObject(EventBus_Publish);
         EventBus.Publish += new EventBus.PublishObject(EventBus_Publish2);
         bo.Update("Fourth Value");
         // UnregisterAllMessages
         EventBus.UnsubcribeAll();
         bo.Update("Fifth Value");
      }
      static void EventBus_Publish(object sender, EventArgs args)
      {
         if (sender is BusinessObject1)
         {
            BusinessObject1 bo1 = (BusinessObject1)sender;
            BusinessObject1.PublishBusinessObject1EventArgs args1 =
               (BusinessObject1.PublishBusinessObject1EventArgs)args;
            Console.WriteLine("Updated {0} to {1}", args1.oldValue, bo1.Value);
         }
      }
      static void EventBus_Publish2(object sender, EventArgs args)
      {
         if (sender is BusinessObject1)
         {
            BusinessObject1 bo1 = (BusinessObject1)sender;
            BusinessObject1.PublishBusinessObject1EventArgs args1 =
               (BusinessObject1.PublishBusinessObject1EventArgs)args;
            Console.WriteLine("Second handler detected updated of {0} to {1}", args1.oldValue, bo1.Value);
         }
      }
    }
    static class EventBus
    {
      public delegate void PublishObject(object sender, EventArgs args);
      public static event PublishObject Publish;
      // PublishEvent
      public static void Update(object sender, EventArgs args)
      {
         if (Publish != null)
            Publish(sender, args);
      }
      public static void UnsubcribeAll()
      {
         Publish = null;
      }
    }
    class BusinessObject1
    {
      public class PublishBusinessObject1EventArgs : EventArgs
      {
         public string oldValue;
         public PublishBusinessObject1EventArgs(string oldValue)
         {
            this.oldValue = oldValue;
         }
      }
      public delegate void PublishBusinessObject1(BusinessObject1 sender, PublishBusinessObject1EventArgs args);
      public string Value { get; private set; }
      public BusinessObject1(string value)
      {
         this.Value = value;
      }
      public void Update(string newValue)
      {
         PublishBusinessObject1EventArgs args = new PublishBusinessObject1EventArgs(Value);
         Value = newValue;
         EventBus.Update(this, args);
      }
    }
