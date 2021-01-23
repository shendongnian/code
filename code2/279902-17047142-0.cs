	public class FirebirdCorrectingReader : IDataReader {
		private readonly IDataReader _decoratedReader;
		public FirebirdCorrectingReader(IDataReader decoratedReader) {
			_decoratedReader = decoratedReader;	
		}
		#region DataReader Impl
		public void Dispose() {
			_decoratedReader.Dispose();
		}
		public string GetName(int i) {
			return _decoratedReader.GetName(i);
		}
		public string GetDataTypeName(int i) {
			return _decoratedReader.GetDataTypeName(i);
		}
		public Type GetFieldType(int i) {
			return _decoratedReader.GetFieldType(i);
		}
		public object GetValue(int i) {
			var result = _decoratedReader.GetValue(i);
			if (result is Guid) {
				result = CorrectGuid((Guid)result);
			}
			return result;
		}
		public int GetValues(object[] values) {
			return _decoratedReader.GetValues(values);
		}
		public int GetOrdinal(string name) {
			return _decoratedReader.GetOrdinal(name);
		}
		public bool GetBoolean(int i) {
			return _decoratedReader.GetBoolean(i);
		}
		public byte GetByte(int i) {
			return _decoratedReader.GetByte(i);
		}
		public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) {
			return _decoratedReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
		}
		public char GetChar(int i) {
			return _decoratedReader.GetChar(i);
		}
		public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) {
			return _decoratedReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
		}
		public Guid GetGuid(int i) {
			return CorrectGuid(_decoratedReader.GetGuid(i));
		}
		public short GetInt16(int i) {
			return _decoratedReader.GetInt16(i);
		}
		public int GetInt32(int i) {
			return _decoratedReader.GetInt32(i);
		}
		public long GetInt64(int i) {
			return _decoratedReader.GetInt64(i);
		}
		public float GetFloat(int i) {
			return _decoratedReader.GetFloat(i);
		}
		public double GetDouble(int i) {
			return _decoratedReader.GetDouble(i);
		}
		public string GetString(int i) {
			return _decoratedReader.GetString(i);
		}
		public decimal GetDecimal(int i) {
			return _decoratedReader.GetDecimal(i);
		}
		public DateTime GetDateTime(int i) {
			return _decoratedReader.GetDateTime(i);
		}
		public IDataReader GetData(int i) {
			return _decoratedReader.GetData(i);
		}
		public bool IsDBNull(int i) {
			return _decoratedReader.IsDBNull(i);
		}
		public int FieldCount { get { return _decoratedReader.FieldCount; } }
		object IDataRecord.this[int i] {
			get { return _decoratedReader[i]; }
		}
		object IDataRecord.this[string name] {
			get {return _decoratedReader[name]; }
		}
		public void Close() {
			_decoratedReader.Close();
		}
		public DataTable GetSchemaTable() {
			return _decoratedReader.GetSchemaTable();
		}
		public bool NextResult() {
			return _decoratedReader.NextResult();
		}
		public bool Read() {
			return _decoratedReader.Read();
		}
		public int Depth { get { return _decoratedReader.Depth; } }
		public bool IsClosed { get { return _decoratedReader.IsClosed; } }
		public int RecordsAffected { get { return _decoratedReader.RecordsAffected; } }
		#endregion
		public static Guid CorrectGuid(Guid badlyParsedGuid) {
			var rfc4122bytes = badlyParsedGuid.ToByteArray();
			if (BitConverter.IsLittleEndian) {
				Array.Reverse(rfc4122bytes, 0, 4);
				Array.Reverse(rfc4122bytes, 4, 2);
				Array.Reverse(rfc4122bytes, 6, 2);
			}
			return new Guid(rfc4122bytes);
		}
	}
