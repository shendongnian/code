	public class Item
	{
		public Item(string key, string content) => (this.key, this.content) = (key, content);
		public string ID { get; set; } = Guid.NewGuid().ToString();
		public string key { get; set; }
		public string content { get; set; }
	}
CosmosDBContext .cs
-------------------
	public class CosmosDBContext : DbContext
	{
		public CosmosDBContext(DbContextOptions<CosmosDBContext> options) : base(options)
		{
		}
		public DbSet<Item> Items { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Set partition key, set container
			modelBuilder.Entity<Item>().HasPartitionKey("key").ToContainer("JackTest");
		}
	}
Create one item:
----------------
	_cosmosDBContext.Items.Add(new Item("aaa", "abcdefg"));
	_cosmosDBContext.SaveChanges(true);
From the data explorer, we can see that the item was created:
[![enter image description here][1]][1]
And we can see that system will generate the default "id".  
Update item
-----------
	var item = _cosmosDBContext.Items.Where(i => i.content.Equals("abcdefg")).FirstOrDefault();
	item.content = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss.fffZ") + item.content;
	_cosmosDBContext.Update(item);
	_cosmosDBContext.SaveChanges(true);
And the item was updated:
[![enter image description here][2]][2]
  [1]: https://i.stack.imgur.com/5EYoL.png
  [2]: https://i.stack.imgur.com/VTYtf.png
