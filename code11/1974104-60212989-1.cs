	public interface IContentReader : IDisposable
	{
		/// <summary>
		/// Move to next record in data source
		/// </summary>
		/// <returns>true, if the operation was performed successfully</returns>
		bool MoveNext();
		/// <summary>
		/// Find value in record by given key index
		/// </summary>
		/// <param name="index">index of value</param>
		/// <returns>null, if given key index was not found</returns>
		string GetValue(int index);
		/// <summary>
		/// Reset state of reader
		/// </summary>
		void Reset();
		/// <summary>
		/// Collection of value keys
		/// </summary>
		IDictionary<int, string> IndexKeyPairs { get; }
	}
