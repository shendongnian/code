    class Program
    {
      static void Main(string[] args)
      {
         BusinessObject1 bo = new BusinessObject1("First Value");
         // Subscribe
         bo.Publish += new BusinessObject.PublishObject(bo_Publish);
         bo.Update("Second Value");
         // UnSubscribe
         bo.Publish -= new BusinessObject.PublishObject(bo_Publish);
         bo.Update("Third Value");
         // Subscribe multiple
         bo.Publish += new BusinessObject.PublishObject(bo_Publish);
         bo.Publish += new BusinessObject.PublishObject(bo_Publish2);
         bo.Update("Fourth Value");
         // UnregisterAllMessages
         bo.UnsubcribeAll();
         bo.Update("Fifth Value");
      }
      static void bo_Publish(BusinessObject sender, EventArgs args)
      {
         if (sender is BusinessObject1)
         {
            BusinessObject1 bo1 = (BusinessObject1)sender;
            BusinessObject1.PublishBusinessObject1EventArgs args1 =
               (BusinessObject1.PublishBusinessObject1EventArgs)args;
            Console.WriteLine("Updated {0} to {1}", args1.oldValue, bo1.Value);
         }
      }
      static void bo_Publish2(BusinessObject sender, EventArgs args)
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
    abstract class BusinessObject
    {
      public delegate void PublishObject(BusinessObject sender, EventArgs args);
      public event PublishObject Publish;
      // PublishEvent
      protected void Update(EventArgs args)
      {
         if (Publish != null)
            Publish(this, args);
      }
      public void UnsubcribeAll()
      {
         Publish = null;
      }
    }
    class BusinessObject1 : BusinessObject
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
      
      public string Value {get; private set;}
      public BusinessObject1(string value)
      {
         this.Value = value;
      }
      public void Update(string newValue)
      {
         PublishBusinessObject1EventArgs args = new PublishBusinessObject1EventArgs(Value);
         Value = newValue;
         base.Update(args);
      }
    }
