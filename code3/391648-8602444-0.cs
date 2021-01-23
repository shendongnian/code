	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Collections.Specialized;
	namespace InterfaceInheranceTest
	{
		class Program
		{
			interface INotifyEnumerableCollectionChanged<T> : IEnumerable<T>, INotifyCollectionChanged {}
			class MyCollection : INotifyEnumerableCollectionChanged<String> // Use your interface
			{
				IEnumerator<String> IEnumerable<String>.GetEnumerator()
				{ throw new NotImplementedException(); }
				System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
				{ throw new NotImplementedException(); }
				public event NotifyCollectionChangedEventHandler CollectionChanged;
			}
			class MyType
			{
				private INotifyEnumerableCollectionChanged<String> _Collection;
				public INotifyEnumerableCollectionChanged<String> Collection
				{
					get { return _Collection;  }
					set
					{
						_Collection = value;
						_Collection.CollectionChanged += new NotifyCollectionChangedEventHandler(_Collection_CollectionChanged);
						foreach (var item in _Collection)
						{
							Console.WriteLine(item);
						}
					}
				}
				void _Collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
				{ throw new NotImplementedException(); }
			}
			static void Main(string[] args)
			{
				var collection = new MyCollection();
				var type = new MyType();
				type.Collection = collection;   // compiler doesn't like this!
			}
		}
	}
