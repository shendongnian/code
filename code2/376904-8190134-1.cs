    using Db4objects.Db4o;
    using Db4objects.Db4o.Events;
    using Db4objects.Db4o.IO;
    using Db4objects.Db4o.Ext;
    
    namespace PushedUpdates
    {
    	class Program
    	{
    		static void Main()
    		{
    			var config = Db4oEmbedded.NewConfiguration();
    			config.File.Storage = new MemoryStorage();
    			var container = Db4oEmbedded.OpenFile(config, "IN-MEMORY");
    
    			var client = container.Ext().OpenSession();
    
    			var clientEvents = EventRegistryFactory.ForObjectContainer(client);
    			clientEvents.Committed += (s, a) =>
    			                          	{
    											foreach(IObjectInfo added in a.Added)
    			                          		{
    			                          			System.Console.WriteLine(added.GetObject());
    			                          		}
    			                          	};
    
    			container.Store(new Item { Value = 1 } );
    			container.Commit();
    			container.Store(new Item { Value = 2 });
    			container.Commit();
    			container.Store(new Item { Value = 3 });
    			container.Commit();
    
    			client.Close();
    			container.Close();
    		}
    	}
    
    	class Item
    	{
    		public int Value { get; set; }
    
    		public override string ToString()
    		{
    			return "" + Value;
    		}
    	}
    }
