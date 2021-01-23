	/// <summary>
	/// This repo enables us to work with serialisable collections. Collection class has
	/// to inherit from IEnumerable and must be described with CollectionDataContract attribute
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ICollectionsRepository<T, V> where T : Collection<V>
	{
		/// <summary>
		/// 	Get collection from datastore
		/// </summary>
		/// <returns>List of items</returns>
		T Load();
		/// <summary>
		/// 	Add new collection item to datastore
		/// </summary>
		/// <param name="item">Item to be added to the collection</param>
		void Add(V item);
	}
	public class XmlCollectionsProvider<T, V> : ICollectionsRepository<T, V> where T: Collection<V>, new() where V: CollectionItem
	{
		private readonly string _file = Path.Combine(XmlProvider.DataStorePhysicalPath, typeof(T).Name + ".xml");
		public T Load()
		{
			if (!DefaultsExist()) {
				CreateDefaults();
			}
			DataContractSerializer dcs = new DataContractSerializer(typeof(T));
			T obj = null;
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateTextReader(new FileStream(_file, FileMode.Open, FileAccess.Read),
																						 new XmlDictionaryReaderQuotas());
			obj = (T)dcs.ReadObject(reader, true);
			reader.Close();
			return obj;
		}
		public void Add(V item)
		{
			T collection = Load();
			collection.Add(item);
			Save(collection);
		}
	}
	[CollectionDataContract(ItemName = "Culture")]
	public sealed class Cultures : List<LangCult>	{	}
	[DataContract]
	public class LangCult : CollectionItem
	{
		...
	}
	[DataContract]
	public abstract class CollectionItem
	{
		[DataMember]
		public string Id
		{
			get;
			set;
		}
	}
