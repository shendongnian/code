	using System;
	using System.Diagnostics;
	using System.Globalization;
	using System.Runtime.CompilerServices;
	using System.Xml;
	using System.Xml.Schema;
	using System.Xml.Serialization;
	namespace Sc.Util.System
	{
		/// <summary>
		/// A class holding <see langword="ulong"/> bit <see cref="Flags"/>.
		/// Flags are numbered from one to sixty-four, from right-to-left in the
		/// <see langword="ulong"/> value --- but the abstraction allows you to
		/// ignore that as an implementation detail. This class implements
		/// methods to set and clear flags, and set and clear flags from other
		/// instances. This also implements implicit conversions to and from
		/// <see langword="ulong"/> --- and therefore you may invoke methods with
		/// <see langword="ulong"/> values. This is also
		/// <see cref="IXmlSerializable"/> and <see cref="ICloneable"/>.
		/// </summary>
		[Serializable]
		public sealed class LongFlags
				: ICloneable,
						IXmlSerializable
		{
			/// <summary>
			/// Counts the bits that are set on the argument.
			/// </summary>
			/// <param name="flags">Arbitrary.</param>
			/// <returns>A count of bits that are set.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static int CountBits(ulong flags)
			{
				int result = 0;
				for (int i = 0; i < 64; ++i) {
					if ((flags & 1) == 1)
						++result;
					flags >>= 1;
				}
				return result;
			}
			/// <summary>
			/// Returns the <see langword="ulong"/> VALUE of the SINGLE
			/// highest bit that is set on the argument.
			/// </summary>
			/// <param name="flags">Arbitrary.</param>
			/// <returns>The value of the single highest bit that is set.
			/// Returns zero if no bits are set.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static ulong GetHighestBitValue(ulong flags)
			{
				int highestBit = LongFlags.GetHighestBitPosition(flags);
				return highestBit == 0
						? 0UL
						: 1UL << (highestBit - 1);
			}
			/// <summary>
			/// Returns the <see langword="ulong"/> VALUE of the SINGLE
			/// lowest bit that is set on the argument.
			/// </summary>
			/// <param name="flags">Arbitrary.</param>
			/// <returns>The value of the single lowest bit that is set.
			/// Returns zero if no bits are set.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static ulong GetLowestBitValue(ulong flags)
			{
				int lowestBit = LongFlags.GetLowestBitPosition(flags);
				return lowestBit == 0
						? 0UL
						: 1UL << (lowestBit - 1);
			}
			/// <summary>
			/// Returns the position of highest bit that is set on the argument:
			/// where the right-most bit is position one; and the left-most is sixty-four.
			/// </summary>
			/// <param name="flags">Arbitrary.</param>
			/// <returns>The position of the highest bit that is set.
			/// Returns zero if no bits are set.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static int GetHighestBitPosition(ulong flags)
			{
				if (flags == 0UL)
					return 0;
				for (int i = 63; i >= 0; --i) {
					if (((flags >> i) & 1) == 1)
						return i + 1;
				}
				Debug.Fail($"Value is '{flags}' but iteration failed to find a set bit.");
				return 0;
			}
			/// <summary>
			/// Returns the position of lowest bit that is set on the argument:
			/// where the right-most bit is position one; and the left-most is sixty-four.
			/// </summary>
			/// <param name="flags">Arbitrary.</param>
			/// <returns>The position of the lowest bit that is set.
			/// Returns zero if no bits are set.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static int GetLowestBitPosition(ulong flags)
			{
				if (flags == 0UL)
					return 0;
				for (int i = 0; i < 64; ++i) {
					if (((flags >> i) & 1) == 1)
						return i + 1;
				}
				Debug.Fail($"Value is '{flags}' but iteration failed to find a set bit.");
				return 0;
			}
			/// <summary>
			/// Returns a new value from the <paramref name="flags"/>
			/// with the <paramref name="predicate"/> removed.
			/// </summary>
			/// <param name="flags">Arbitrary.</param>
			/// <param name="predicate">Arbitrary.</param>
			/// <returns>Returns <paramref name="flags"/> <c>&</c> the
			/// complement of the <paramref name="predicate"/>.</returns>
			public static ulong Excluding(ulong flags, ulong predicate)
				=> flags & ~predicate;
			/// <summary>
			/// Returns true if the <paramref name="source"/> has ANY of the bits that
			/// are set on the <paramref name="flags"/>. Notice that if the
			/// <paramref name="flags"/> are zero, this will return false.
			/// </summary>
			/// <param name="source">The source flags.
			/// If zero, this will return false.</param>
			/// <param name="flags">Arbitrary bits to search for.
			/// If zero, this will return false.</param>
			/// <returns>True if ANY <The name="flags"/> are present on the
			/// <paramref name="source"/> (and at least one flags bit is set).</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool HasAnyBits(ulong source, ulong flags)
				=> (source & flags) != 0UL;
			/// <summary>
			/// Returns true if the <paramref name="source"/> has ALL of the bits that
			/// are set on the <paramref name="flags"/>. Notice that if the
			/// <paramref name="flags"/> are zero, this will return false.
			/// </summary>
			/// <param name="source">The source flags.
			/// If zero, this will return false.</param>
			/// <param name="flags">Arbitrary bits to search for.
			/// If zero, this will return false.</param>
			/// <returns>True if ALL <The name="flags"/> are present on the
			/// <paramref name="source"/> (and at least one flags bit is set).</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool HasAllBits(ulong source, ulong flags)
				=> (flags != 0UL) && ((source & flags) == flags);
			/// <summary>
			/// Returns true if the <paramref name="source"/> has ONLY bits that are set
			/// on the <paramref name="flags"/> --- false if any bit is set on the source
			/// that is not defined on the flags. Notice that if the
			/// <paramref name="flags"/> are zero, this will return false.
			/// </summary>
			/// <param name="source">The source flags.
			/// If zero, this will return false.</param>
			/// <param name="flags">Arbitrary bits to search for.
			/// If zero, this will return false.</param>
			/// <param name="requiresAll">If true, then <paramref name="source"/>
			/// MUST contain ALL <paramref name="flags"/> AND NO other bits.
			/// If false, the source may contain zero or more bits
			/// present on the flags --- and no bits that are not present on the flags
			/// (source need not contain all, but can only contain a bit on the flags).</param>
			/// <returns>True if only the flags are present on the source --- false if any bit is
			/// set on th source that is not defined on the flags.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool HasOnlyBits(ulong source, ulong flags, bool requiresAll)
				=> (flags != 0UL)
						&& (source != 0UL)
						&& ((source & ~flags) == 0UL)
						&& (!requiresAll
						|| ((source & flags) == flags));
			/// <summary>
			/// Returns true if the <paramref name="source"/> has NONE of the
			/// bits that are set on <paramref name="flags"/>. Notice that if the
			/// <paramref name="flags"/> are zero, this will return TRUE.
			/// </summary>
			/// <param name="source">The source flags.
			/// If zero, this will return true.</param>
			/// <param name="flags">Arbitrary flags to search for.
			/// If zero, this will return true.</param>
			/// <returns>True if no flags bits are set here.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool HasNoBits(ulong source, ulong flags)
				=> (source & flags) == 0UL;
			/// <summary>
			/// Checks the range.
			/// </summary>
			/// <param name="position">[1,64].</param>
			/// <exception cref="ArgumentOutOfRangeException"></exception>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static void rangeCheckPosition(int position)
			{
				if ((position <= 0)
						|| (position > 64))
					throw new ArgumentOutOfRangeException(nameof(position), position, @"[1,64]");
			}
			/// <summary>
			/// Default constructor creates an empty instance.
			/// </summary>
			public LongFlags() { }
			/// <summary>
			/// Creates a new instance with each flag position in the argument array set.
			/// </summary>
			/// <param name="flags">The flags to set.</param>
			/// <exception cref="ArgumentOutOfRangeException"></exception>
			public LongFlags(params int[] flags)
				=> Set(flags);
			/// <summary>
			/// Creates a new instance with the given bits set.
			/// </summary>
			/// <param name="flags">The bits to copy. This directly
			/// sets <see cref="Flags"/>.</param>
			public LongFlags(ulong flags)
				=> Flags = flags;
			/// <summary>
			/// Creates a deep clone of the argument.
			/// </summary>
			/// <param name="clone">The value to copy.</param>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private LongFlags(LongFlags clone)
				=> Flags = clone.Flags;
			XmlSchema IXmlSerializable.GetSchema()
				=> null;
			void IXmlSerializable.WriteXml(XmlWriter writer)
				=> writer.WriteString(Flags.ToString(CultureInfo.InvariantCulture));
			void IXmlSerializable.ReadXml(XmlReader reader)
			{
				if (reader.IsEmptyElement)
					Flags = 0UL;
				else {
					reader.Read();
					switch (reader.NodeType) {
						case XmlNodeType.EndElement :
							Flags = 0UL; // empty after all...
							break;
						case XmlNodeType.Text :
						case XmlNodeType.CDATA :
							Flags = ulong.Parse(reader.ReadContentAsString(), CultureInfo.InvariantCulture);
							break;
						default :
							throw new InvalidOperationException("Expected text/cdata");
					}
				}
			}
			/// <summary>
			/// The current bit flags. Flags are numbered from one to sixty-four: where
			/// the right-most bit is one, and the left-most is sixty four.
			/// Methods do not require knowledge of the flag positions; and flags
			/// are simply numbered [1,64].
			/// </summary>
			public ulong Flags
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get;
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private set;
			}
			/// <summary>
			/// An indexer that gets or sets a boolean indicating if the flag at the
			/// given <paramref name="position"/> is set.
			/// </summary>
			/// <param name="position">[1,64].</param>
			/// <returns>True if the flag is set.</returns>
			public bool this[int position]
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => IsSet(position);
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set {
					if (value)
						Set(position);
					else
						Clear(position);
				}
			}
			/// <summary>
			/// Returns true if the flag at the given position is set.
			/// </summary>
			/// <param name="position">The position to test: [1,64].</param>
			/// <returns>True if the flag is set.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool IsSet(int position)
			{
				LongFlags.rangeCheckPosition(position);
				return LongFlags.HasAnyBits(Flags, 1UL << (position - 1));
			}
			/// <summary>
			/// Returns true if each flag in the argument array is set.
			/// This will return FALSE if none are provided.
			/// </summary>
			/// <param name="positions">[1,64].</param>
			/// <returns>True if all provided flags are set. NOTICE: this will
			/// return FALSE if none are provided.</returns>
			public bool IsAllSet(params int[] positions)
			{
				if (positions.Length == 0)
					return false;
				foreach (int position in positions) {
					if (!IsSet(position))
						return false;
				}
				return true;
			}
			/// <summary>
			/// Returns true if ANY flag in the argument array is set.
			/// This will return FALSE if none are provided.
			/// </summary>
			/// <param name="positions">[1,64].</param>
			/// <returns>True if ANY provided flag is set; AND if AT LEAST ONE
			/// is provided.</returns>
			public bool IsAnySet(params int[] positions)
			{
				foreach (int position in positions) {
					if (IsSet(position))
						return true;
				}
				return false;
			}
			/// <summary>
			/// Returns true if all flags are set.
			/// </summary>
			public bool IsFull
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => Flags == ulong.MaxValue;
			}
			/// <summary>
			/// Returns true if no flags are set.
			/// </summary>
			public bool IsEmpty
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => Flags == 0UL;
			}
			/// <summary>
			/// Counts the flags that are set.
			/// </summary>
			/// <returns>A count of <see cref="Flags"/> bits that are set.</returns>
			public int Count
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => LongFlags.CountBits(Flags);
			}
			/// <summary>
			/// Returns the position of highest flag that is set.
			/// </summary>
			/// <returns>The position of the highest bit that is set on <see cref="Flags"/>.</returns>
			public int HighestFlag
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => LongFlags.GetHighestBitPosition(Flags);
			}
			/// <summary>
			/// Returns the position of lowest flag that is set.
			/// </summary>
			/// <returns>The position of the lowest bit that is set on <see cref="Flags"/>.</returns>
			public int LowestFlag
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => LongFlags.GetLowestBitPosition(Flags);
			}
			/// <summary>
			/// Returns the <see langword="ulong"/> VALUE of the SINGLE
			/// highest bit that is set.
			/// </summary>
			/// <returns>The value of the single highest bit that is set on <see cref="Flags"/>.</returns>
			public ulong HighestFlagValue
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => LongFlags.GetHighestBitValue(Flags);
			}
			/// <summary>
			/// Returns the <see langword="ulong"/> VALUE of the SINGLE
			/// lowest bit that is set.
			/// </summary>
			/// <returns>The value of the single lowest bit that is set on <see cref="Flags"/>.</returns>
			public ulong LowestFlagValue
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => LongFlags.GetLowestBitValue(Flags);
			}
			/// <summary>
			/// Sets the flag at the position specified by the argument.
			/// </summary>
			/// <param name="position">[1,64].</param>
			/// <returns>This object for chaining.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public LongFlags Set(int position)
			{
				LongFlags.rangeCheckPosition(position);
				Flags |= 1UL << (position - 1);
				return this;
			}
			/// <summary>
			/// Sets the flag at each specified position.
			/// </summary>
			/// <param name="positions">[1,64].</param>
			/// <returns>This object for chaining.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public LongFlags Set(params int[] positions)
			{
				ulong flags = Flags;
				try {
					foreach (int position in positions) {
						Set(position);
					}
					return this;
				} catch {
					Flags = flags;
					throw;
				}
			}
			/// <summary>
			/// Sets all flags to one.
			/// </summary>
			/// <returns>This object for chaining.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public LongFlags SetAll()
			{
				Flags = ulong.MaxValue;
				return this;
			}
			/// <summary>
			/// Clears the flag at the position specified by the argument.
			/// </summary>
			/// <param name="position">[1,64].</param>
			/// <returns>This object for chaining.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public LongFlags Clear(int position)
			{
				LongFlags.rangeCheckPosition(position);
				Flags &= ~(1UL << (position - 1));
				return this;
			}
			/// <summary>
			/// Clears the flag at each position specified in the argument array.
			/// </summary>
			/// <param name="positions">[1,64].</param>
			/// <returns>This object for chaining.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public LongFlags Clear(params int[] positions)
			{
				ulong flags = Flags;
				try {
					foreach (int position in positions) {
						Clear(position);
					}
					return this;
				} catch {
					Flags = flags;
					throw;
				}
			}
			/// <summary>
			/// Resets all <see cref="Flags"/> to zero.
			/// </summary>
			/// <returns>This object for chaining.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public LongFlags Clear()
			{
				Flags = 0UL;
				return this;
			}
			/// <summary>
			/// Sets <see cref="Flags"/> to the argument's value.
			/// </summary>
			/// <param name="clone">The value to copy.</param>
			/// <returns>This object for chaining.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public LongFlags SetFrom(LongFlags clone)
			{
				Flags = clone.Flags;
				return this;
			}
			/// <summary>
			/// Sets <see cref="Flags"/> to the argument's value.
			/// </summary>
			/// <param name="clone">The value to copy.</param>
			/// <returns>This object for chaining.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public LongFlags SetFrom(ulong clone)
			{
				Flags = clone;
				return this;
			}
			/// <summary>
			/// Adds all of the flags in the argument to this instance.
			/// </summary>
			/// <param name="flags">Arbitrary flags to add.</param>
			/// <returns>This object for chaining.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public LongFlags AddAllFlags(LongFlags flags)
			{
				Flags |= flags.Flags;
				return this;
			}
			/// <summary>
			/// Removes all flags defined on the argument from this instance.
			/// </summary>
			/// <param name="flags">Arbitrary flags to remove.</param>
			/// <returns>This object for chaining.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public LongFlags RemoveAllFlags(LongFlags flags)
			{
				Flags &= ~flags.Flags;
				return this;
			}
			/// <summary>
			/// Returns true if this instance has ANY of the <see cref="Flags"/>
			/// defined on the argument. Notice that if the
			/// <paramref name="flags"/> are zero, this will return false.
			/// </summary>
			/// <param name="flags">Arbitrary flags to search for.</param>
			/// <returns>True if any flags are present here
			/// (and at least one flag bit is set).</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool HasAny(LongFlags flags)
				=> LongFlags.HasAnyBits(Flags, flags.Flags);
			/// <summary>
			/// Returns true if this instance has ALL of the <see cref="Flags"/>
			/// defined on the argument. Notice that if the
			/// <paramref name="flags"/> are zero, this will return false.
			/// </summary>
			/// <param name="flags">Arbitrary flags to search for.</param>
			/// <returns>True if ALL flags are present here
			/// (and at least one flag bit is set).</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool HasAll(LongFlags flags)
				=> LongFlags.HasAllBits(Flags, flags.Flags);
			/// <summary>
			/// Returns true if this instance has ONLY flags that are set
			/// on the <paramref name="flags"/> --- false if any flag is set here
			/// that is not defined on the flags. Notice that if the
			/// <paramref name="flags"/> are zero, this will return false
			/// --- and if this <see cref="Flags"/> is zero this returns false.
			/// </summary>
			/// <param name="flags">Arbitrary flags to search for.
			/// If zero, this will return false.</param>
			/// <param name="requiresAll">If true, then this
			/// MUST contain ALL <paramref name="flags"/> AND NO other flags.
			/// If false, this may contain zero or more flags
			/// present on the flags --- and no flags that are not present on the flags
			/// (this need not contain all, but can only contain a flag on the flags).</param>
			/// <returns>True if only the flags are present here --- false if any flag is
			/// set here that is not defined on the flags.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool HasOnly(LongFlags flags, bool requiresAll)
				=> LongFlags.HasOnlyBits(Flags, flags.Flags, requiresAll);
			/// <summary>
			/// Returns true if this instance has NONE of the <see cref="Flags"/>
			/// defined on the argument.
			/// </summary>
			/// <param name="flags">Arbitrary.</param>
			/// <returns>True if no flags are present here.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool HasNone(LongFlags flags)
				=> LongFlags.HasNoBits(Flags, flags.Flags);
			/// <summary>
			/// Returns a deep clone of this object.
			/// </summary>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public LongFlags Clone()
				=> new LongFlags(this);
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			object ICloneable.Clone()
				=> Clone();
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static implicit operator ulong(LongFlags longFlags)
				=> longFlags.Flags;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static implicit operator LongFlags(ulong flags)
				=> new LongFlags(flags);
			public override string ToString()
				=> $"{nameof(LongFlags)}"
						+ "["
						+ $"{Convert.ToString((byte)(Flags >> 56), 2)}"
						+ $" {Convert.ToString((byte)(Flags >> 48), 2)}"
						+ $" {Convert.ToString((byte)(Flags >> 40), 2)}"
						+ $" {Convert.ToString((byte)(Flags >> 32), 2)}"
						+ $" {Convert.ToString((byte)(Flags >> 24), 2)}"
						+ $" {Convert.ToString((byte)(Flags >> 16), 2)}"
						+ $" {Convert.ToString((byte)(Flags >> 8), 2)}"
						+ $" {Convert.ToString((byte)Flags, 2)}"
						+ "]";
		}
	}
