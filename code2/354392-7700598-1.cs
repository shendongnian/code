    public struct Structure
	{
		public Int32? PK { get; set; }
	}
	public class MyComparer<T> : IEqualityComparer<T>
	{
		#region IEqualityComparer<T> Members
		public bool Equals(T x, T y) {
			return x.Equals(y);
		}
		public int GetHashCode(T obj) {
			throw new NotImplementedException();
		}
		#endregion
	}
    [TestMethod]
		public void EqualityComparerTest() {
			IEqualityComparer<Structure> comparer = new MyComparer<Structure>();
			Structure[] structures = new Structure[] { 
				new Structure { PK = 1 }, new Structure { PK = 1 },
				new Structure { PK = 2 }, new Structure { PK = 3 },
				new Structure { PK = 3 }, new Structure { PK = 4 },
			};
    //TODO: set breakpoint in Equals and GetHashCode methods, and see which is called
			var distinct = structures.Distinct(comparer).ToArray();
		}
