    public abstract class DomainObjectCollection {
		public abstract void Save();
	}
	public class DomainObjectCollection<T> : DomainObjectCollection where T : IDomainObject {
		private readonly Collection<T> collection;
		public DomainObjectCollection(Collection<T> collection) {
			this.collection = collection;
		}
		public static implicit operator DomainObjectCollection<T> (Collection<T> collection) {
			return new DomainObjectCollection<T>(collection);
		}
		public override void Save() {
			foreach (var obj in collection)
				obj.Save();
		}
	}
	public class DomainObject : IDomainObject {
		private readonly IList<DomainObjectCollection> m_Collections = new List<DomainObjectCollection>();
		protected void RegisterCollection<T>(Collection<T> collection) where T : IDomainObject {
			m_Collections.Add((DomainObjectCollection<T>)collection);
		}
		/// <summary>
		/// Saves this instance collections.
		/// </summary>
		public virtual void Save() {
			SaveCollections();
		}
		private void SaveCollections() {
			foreach (var itemCollection in m_Collections) {
				itemCollection.Save();
			}
		}
	}
