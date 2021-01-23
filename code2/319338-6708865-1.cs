		public sealed class Symbol : IEquatable<Symbol>
		{
			public string FileName { get; set; }
			public DateTime FileDate { get; set; }
			public long CRC32 { get; set; }
			public bool Equals(Symbol other)
			{
				if (other == null)
				{
					return false;
				}
				return FileName == other.FileName &&
				       (FileDate == other.FileDate || CRC32 == other.CRC32);
			}
			public override bool Equals(object obj)
			{
				return Equals(obj as Symbol);
			}
			public override int GetHashCode()
			{
				// since FileName must be equal (others may or may not)
				// can use its hash code as your surrogate hash code.
				return FileName.GetHashCode();
			}
		}
