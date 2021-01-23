    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace MyNameSpace
    {
        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1010:CollectionsShouldImplementGenericInterface")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
        public class UtcDbDataReader : DbDataReader
        {
            private readonly DbDataReader source;
    
            public UtcDbDataReader(DbDataReader source)
            {
                this.source = source;
            }
    
            /// <inheritdoc />
            public override int VisibleFieldCount => source.VisibleFieldCount;
    
            /// <inheritdoc />
            public override int Depth => source.Depth;
    
            /// <inheritdoc />
            public override int FieldCount => source.FieldCount;
    
            /// <inheritdoc />
            public override bool HasRows => source.HasRows;
    
            /// <inheritdoc />
            public override bool IsClosed => source.IsClosed;
    
            /// <inheritdoc />
            public override int RecordsAffected => source.RecordsAffected;
    
            /// <inheritdoc />
            public override object this[string name] => source[name];
    
            /// <inheritdoc />
            public override object this[int ordinal] => source[ordinal];
    
            /// <inheritdoc />
            public override bool GetBoolean(int ordinal)
            {
                return source.GetBoolean(ordinal);
            }
    
            /// <inheritdoc />
            public override byte GetByte(int ordinal)
            {
                return source.GetByte(ordinal);
            }
    
            /// <inheritdoc />
            public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
            {
                return source.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
            }
    
            /// <inheritdoc />
            public override char GetChar(int ordinal)
            {
                return source.GetChar(ordinal);
            }
    
            /// <inheritdoc />
            public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
            {
                return source.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
            }
    
            /// <inheritdoc />
            public override string GetDataTypeName(int ordinal)
            {
                return source.GetDataTypeName(ordinal);
            }
    
            /// <summary>
            /// Returns datetime with Utc kind
            /// </summary>
            public override DateTime GetDateTime(int ordinal)
            {
                return DateTime.SpecifyKind(source.GetDateTime(ordinal), DateTimeKind.Utc);
            }
    
            /// <inheritdoc />
            public override decimal GetDecimal(int ordinal)
            {
                return source.GetDecimal(ordinal);
            }
    
            /// <inheritdoc />
            public override double GetDouble(int ordinal)
            {
                return source.GetDouble(ordinal);
            }
    
            /// <inheritdoc />
            public override IEnumerator GetEnumerator()
            {
                return source.GetEnumerator();
            }
    
            /// <inheritdoc />
            public override Type GetFieldType(int ordinal)
            {
                return source.GetFieldType(ordinal);
            }
    
            /// <inheritdoc />
            public override float GetFloat(int ordinal)
            {
                return source.GetFloat(ordinal);
            }
    
            /// <inheritdoc />
            public override Guid GetGuid(int ordinal)
            {
                return source.GetGuid(ordinal);
            }
    
            /// <inheritdoc />
            public override short GetInt16(int ordinal)
            {
                return source.GetInt16(ordinal);
            }
    
            /// <inheritdoc />
            public override int GetInt32(int ordinal)
            {
                return source.GetInt32(ordinal);
            }
    
            /// <inheritdoc />
            public override long GetInt64(int ordinal)
            {
                return source.GetInt64(ordinal);
            }
    
            /// <inheritdoc />
            public override string GetName(int ordinal)
            {
                return source.GetName(ordinal);
            }
    
            /// <inheritdoc />
            public override int GetOrdinal(string name)
            {
                return source.GetOrdinal(name);
            }
    
            /// <inheritdoc />
            public override string GetString(int ordinal)
            {
                return source.GetString(ordinal);
            }
    
            /// <inheritdoc />
            public override object GetValue(int ordinal)
            {
                return source.GetValue(ordinal);
            }
    
            /// <inheritdoc />
            public override int GetValues(object[] values)
            {
                return source.GetValues(values);
            }
    
            /// <inheritdoc />
            public override bool IsDBNull(int ordinal)
            {
                return source.IsDBNull(ordinal);
            }
    
            /// <inheritdoc />
            public override bool NextResult()
            {
                return source.NextResult();
            }
    
            /// <inheritdoc />
            public override bool Read()
            {
                return source.Read();
            }
    
            /// <inheritdoc />
            public override void Close()
            {
                source.Close();
            }
    
            /// <inheritdoc />
            public override T GetFieldValue<T>(int ordinal)
            {
                return source.GetFieldValue<T>(ordinal);
            }
    
            /// <inheritdoc />
            public override Task<T> GetFieldValueAsync<T>(int ordinal, CancellationToken cancellationToken)
            {
                return source.GetFieldValueAsync<T>(ordinal, cancellationToken);
            }
    
            /// <inheritdoc />
            public override Type GetProviderSpecificFieldType(int ordinal)
            {
                return source.GetProviderSpecificFieldType(ordinal);
            }
    
            /// <inheritdoc />
            public override object GetProviderSpecificValue(int ordinal)
            {
                return source.GetProviderSpecificValue(ordinal);
            }
    
            /// <inheritdoc />
            public override int GetProviderSpecificValues(object[] values)
            {
                return source.GetProviderSpecificValues(values);
            }
    
            /// <inheritdoc />
            public override DataTable GetSchemaTable()
            {
                return source.GetSchemaTable();
            }
    
            /// <inheritdoc />
            public override Stream GetStream(int ordinal)
            {
                return source.GetStream(ordinal);
            }
    
            /// <inheritdoc />
            public override TextReader GetTextReader(int ordinal)
            {
                return source.GetTextReader(ordinal);
            }
    
            /// <inheritdoc />
            public override Task<bool> IsDBNullAsync(int ordinal, CancellationToken cancellationToken)
            {
                return source.IsDBNullAsync(ordinal, cancellationToken);
            }
    
            /// <inheritdoc />
            public override Task<bool> ReadAsync(CancellationToken cancellationToken)
            {
                return source.ReadAsync(cancellationToken);
            }
    
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly")]
            public new void Dispose()
            {
                source.Dispose();
            }
    
            public new IDataReader GetData(int ordinal)
            {
                return source.GetData(ordinal);
            }
        }
    }
