	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading;
	namespace System
	{
		/// <summary>
		/// Defined in Totlsoft.Util.
		/// A key that will always be unique but compares
		/// primarily on the Key property, which is not required
		/// to be unique.
		/// </summary>
		public struct StableKey : IComparable<StableKey>, IComparable
		{
			private static long s_Next;
			private long m_Sequence;
			private IComparable m_Key;
			/// <summary>
			/// Defined in Totlsoft.Util.
			/// Constructs a StableKey with the given IComparable key.
			/// </summary>
			/// <param name="key"></param>
			public StableKey( IComparable key )
			{
				if( null == key )
					throw new ArgumentNullException( "key" );
				m_Sequence = Interlocked.Increment( ref s_Next );
				m_Key = key;
			}
			/// <summary>
			/// Overridden. True only if internal sequence and the
			/// Key are equal.
			/// </summary>
			/// <param name="obj"></param>
			/// <returns></returns>
			public override bool Equals( object obj )
			{
				if( !( obj is StableKey ) )
					return false;
				var dk = (StableKey)obj;
				return m_Sequence.Equals( dk.m_Sequence ) &&
					Key.Equals( dk.Key );
			}
			/// <summary>
			/// Overridden. Gets the hash code of the internal
			/// sequence and the Key.
			/// </summary>
			/// <returns></returns>
			public override int GetHashCode()
			{
				return m_Sequence.GetHashCode() ^ Key.GetHashCode();
			}
			/// <summary>
			/// Overridden. Returns Key.ToString().
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				return Key.ToString();
			}
			/// <summary>
			/// The key that will be compared on.
			/// </summary>
			public IComparable Key
			{
				get
				{
					if( null == m_Key )
						return 0;
					return m_Key;
				}
			}
			#region IComparable<StableKey> Members
			/// <summary>
			/// Compares this Key property to another. If they
			/// are the same, compares the incremented value.
			/// </summary>
			/// <param name="other"></param>
			/// <returns></returns>
			public int CompareTo( StableKey other )
			{
				var cmp = Key.CompareTo( other.Key );
				if( cmp == 0 )
					cmp = m_Sequence.CompareTo( other.m_Sequence );
				return cmp;
			}
			#endregion
			#region IComparable Members
			int IComparable.CompareTo( object obj )
			{
				return CompareTo( (StableKey)obj );
			}
			#endregion
		}
	}
