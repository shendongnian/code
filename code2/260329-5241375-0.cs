    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    [Serializable]
    [Microsoft.SqlServer.Server.SqlUserDefinedAggregate(
        Format.UserDefined,
        IsInvariantToDuplicates = true,
        IsInvariantToNulls = true,
        MaxByteSize = -1
        )]
    public struct SumKeys : IBinarySerialize
    {
        private readonly static char sep = ',';
        private SqlString result;
        public void Init()
        {
            result = string.Empty;
        }
        public void Accumulate(SqlInt32 value)
        {
            if (!value.IsNull && !Contains(value))
                this.Add(value);
        }
        private void Add(SqlInt32 value)
        {
            this.result += Wrap(value);
        }
        private void Add(string value)
        {
            Add(Convert.ToInt32(value));
        }
        private static string Wrap(SqlInt32 value)
        {
            return value.Value.ToString() + sep;
        }
        private bool Contains(SqlInt32 value)
        {
            return this.result.Value.Contains(Wrap(value));
        }
        public void Merge(SumKeys group)
        {
            foreach (var value in Items(group))
                if (!this.Contains(value))
                    this.Add(value);
        }
        private static IEnumerable<SqlInt32> Items(SumKeys group)
        {
            foreach (var value in group.result.Value.Split(sep))
            {
                int i;
                if (Int32.TryParse(value, out i))
                    yield return i;
            }
        }
        public SqlString Terminate()
        {
            return this.result.Value.TrimEnd(sep);
        }
        public void Read(System.IO.BinaryReader r)
        {
            this.result = r.ReadString();
        }
        public void Write(System.IO.BinaryWriter w)
        {
            w.Write(this.result.Value.TrimEnd(sep));
        }
    }
