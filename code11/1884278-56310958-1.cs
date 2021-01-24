		/// <summary>
		/// Helper for bit flags, that tracks a <see cref="CurrentBit"/>.
		/// The <see cref="BitLimit"/> is limited to sixty-four.
		/// Bit positions are numbered from one to sixty-four,
		/// right-to-left (lsb is one, msb is 64).
		/// </summary>
		[DataContract]
		public class BitHelper
		{
			[DataMember]
			private LongFlags longFlags = new LongFlags();
			/// <summary>
			/// Constructor.
			/// </summary>
			/// <param name="bitLimit">Required: sets <see cref="BitLimit"/>.</param>
			/// <exception cref="ArgumentOutOfRangeException"></exception>
			public BitHelper(int bitLimit)
			{
				if ((bitLimit < 1)
						|| (bitLimit > 64))
					throw new ArgumentOutOfRangeException(nameof(bitLimit), bitLimit, @"[1, 64]");
				BitLimit = bitLimit;
			}
			/// <summary>
			/// Limits the highest bit that can be set. [1, 64].
			/// (Bit positions are numbered from one to a maximum of sixty-four,
			/// right-to-left (lsb is one, msb is 64).)
			/// </summary>
			[DataMember]
			public int BitLimit { get; private set; }
			/// <summary>
			/// Identifies the current working bit position.
			/// Defaults to one. Ranges: [1, BitLimit].
			/// (Bit positions are numbered from one to a maximum of sixty-four,
			/// right-to-left (lsb is one, msb is 64).)
			/// </summary>
			[DataMember]
			public int CurrentBit { get; private set; } = 1;
			/// <summary>
			/// Returns the state of the <see cref="CurrentBit"/>.
			/// </summary>
			/// <returns>True if one, false if zero.</returns>
			public bool IsCurrentBitSet
				=> longFlags[CurrentBit];
			/// <summary>
			/// Increments the <see cref="CurrentBit"/>,
			/// making no changes to bit values.
			/// </summary>
			/// <returns>This object for chaining.</returns>
			/// <exception cref="InvalidOperationException">If the <see cref="CurrentBit"/>
			/// is already at the <see cref="BitLimit"/>.</exception>
			public BitHelper IncrementCurrentBit()
			{
				if (CurrentBit >= BitLimit)
					throw new InvalidOperationException(BitLimit.ToString());
				++CurrentBit;
				return this;
			}
			/// <summary>
			/// Sets the <see cref="CurrentBit"/> to one.
			/// </summary>
			/// <returns>This object for chaining.</returns>
			public BitHelper SetCurrentBit()
			{
				longFlags.Set(CurrentBit);
				return this;
			}
			/// <summary>
			/// Sets the <see cref="CurrentBit"/> to zero.
			/// </summary>
			/// <returns>This object for chaining.</returns>
			public BitHelper ClearCurrentBit()
			{
				longFlags.Clear(CurrentBit);
				return this;
			}
			/// <summary>
			/// Inverts the value of the <see cref="CurrentBit"/>.
			/// </summary>
			/// <returns>This object for chaining.</returns>
			public BitHelper InvertCurrentBit()
			{
				longFlags[CurrentBit] = !longFlags[CurrentBit];
				return this;
			}
			/// <summary>
			/// Returns the position of the highest bit that is set:
			/// [0, BitLimit]. Returns zero if no bits are set.
			/// </summary>
			public int HighestSetBit
				=> longFlags.HighestFlag;
			/// <summary>
			/// Returns all 64 bits as a ULong.
			/// </summary>
			/// <returns>All 64 bits, unsigned.</returns>
			public ulong ToULong()
				=> longFlags.Flags;
			/// <summary>
			/// Returns all 64 bits as a Long.
			/// </summary>
			/// <returns>All 64 bits, signed.</returns>
			public long ToLong()
				=> (long)longFlags.Flags;
			/// <summary>
			/// Returns the lower 32 bits as a UInt
			/// --- REGARDLESS of the setting of <see cref="BitLimit"/>.
			/// </summary>
			/// <returns>The lower 32 bits, unsigned.</returns>
			public uint ToUInt()
				=> (uint)longFlags.Flags;
			/// <summary>
			/// Returns the lower 32 bits as an Int
			/// --- REGARDLESS of the setting of <see cref="BitLimit"/>.
			/// </summary>
			/// <returns>The lower 32 bits, signed.</returns>
			public int ToInt()
				=> (int)longFlags.Flags;
			/// <summary>
			/// Returns the lower 16 bits as a UShort
			/// --- REGARDLESS of the setting of <see cref="BitLimit"/>.
			/// </summary>
			/// <returns>The lower 16 bits, unsigned.</returns>
			public ushort ToUShort()
				=> (ushort)longFlags.Flags;
			/// <summary>
			/// Returns the lower 16 bits as a short
			/// --- REGARDLESS of the setting of <see cref="BitLimit"/>.
			/// </summary>
			/// <returns>The lower 16 bits, signed.</returns>
			public short ToShort()
				=> (short)longFlags.Flags;
			/// <summary>
			/// Returns the lower 8 bits as a Byte
			/// --- REGARDLESS of the setting of <see cref="BitLimit"/>.
			/// </summary>
			/// <returns>The lower 8 bits, unsigned.</returns>
			public byte ToByte()
				=> (byte)longFlags.Flags;
			/// <summary>
			/// Returns the lower 8 bits as an SByte
			/// --- REGARDLESS of the setting of <see cref="BitLimit"/>.
			/// </summary>
			/// <returns>The lower 8 bits, signed.</returns>
			public sbyte ToSByte()
				=> (sbyte)longFlags.Flags;
		}
