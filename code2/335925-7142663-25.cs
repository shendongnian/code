	// our data source base class; could do interface instead like:
	// public interface IInfostoreBase
	public abstract class InfostoreBase
	{
		public abstract int Information { get; set; }
		public abstract string NameOfItem { get; set; }
		public abstract decimal Cost { get; set; }
		// ... etc ...
	}
