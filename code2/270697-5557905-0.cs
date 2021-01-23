    static void Main(string[] args)
		{
			EntityCollection<string> col = new EntityCollection<string>();
			EntityCollectionObserver<string> colObserver = new EntityCollectionObserver<string>(col);
			colObserver.CollectionChanged += colObserver_CollectionChanged;
			col.Add("foo");
		}
		static void colObserver_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			Console.WriteLine("Entity Collection Changed");
		}
