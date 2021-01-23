    [StructLayout(LayoutKind.Explicit, Size = 1, CharSet = CharSet.Ansi)]
	public struct MyUnion
	{
		#region Lifetime
		/// <summary>
		/// Ctor
		/// </summary>
		/// <param name="foo"></param>
		public MyUnion(int foo)
		{
			// allocate the bitfield
			info = new BitVector32(0);
			// initialize bitfield sections
			flag1 = BitVector32.CreateSection(1);
			flag2 = BitVector32.CreateSection(1, flag1);
			flag3 = BitVector32.CreateSection(1, flag2);
		}
		#endregion
		#region Bifield
		// Creates and initializes a BitVector32.
		[FieldOffset(0)]
		private BitVector32 info;
		#endregion
		#region Bitfield sections
		[FieldOffset(4)]
		private readonly BitVector32.Section flag1;
		[FieldOffset(8)]
		private readonly BitVector32.Section flag2;
		[FieldOffset(12)]
		private readonly BitVector32.Section flag3;
		#endregion
		#region Properties
		/// <summary>
		/// Flag 1
		/// </summary>
		public bool Flag1
		{
			get { return info[flag1] != 0; }
			set { info[flag1] = value ? 1 : 0; }
		}
		/// <summary>
		/// Flag 2
		/// </summary>
		public bool Flag2
		{
			get { return info[flag2] != 0; }
			set { info[flag2] = value ? 1 : 0; }
		}
		/// <summary>
		/// Flag 3
		/// </summary>
		public bool Flag3
		{
			get { return info[flag3] != 0; }
			set { info[flag3] = value ? 1 : 0; }
		}
		#endregion
	}
