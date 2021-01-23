	public static bool PossiblyUninitialized(object a) {
		if(a == null) return true;
		Type t = a.GetType();
		return t.IsValueType &&
			helpers.GetOrAdd(t, _=>{
				var method = typeof(StructHelpers<>).MakeGenericType(t)
					.GetMethod("PossiblyUninitialized");
				var objParam = Expression.Parameter(typeof(object),"obj");
				return Expression.Lambda<Func<object,bool>>(
						Expression.Call(method,Expression.Convert(objParam,t)),
						objParam
					).Compile();
			})(a);
	}
	static ConcurrentDictionary<Type, Func<object,bool>> helpers = 
						new ConcurrentDictionary<Type, Func<object,bool>>();
	
	unsafe static class StructHelpers<T> where T : struct { 
		public static readonly uint ByteCount = SizeOf();
		
		static uint SizeOf()
		{
			T[] arr = new T[2];
			var handle = GCHandle.Alloc(arr);
			TypedReference
				elem0 = __makeref(arr[0]),
				elem1 = __makeref(arr[1]);
			return (uint)((byte*)*(IntPtr*)(&elem1) - (byte*)*(IntPtr*)(&elem0)); 
			handle.Free();
		}
		
		public static bool PossiblyUninitialized(T a)
		{
			TypedReference pA = __makeref(a);
			var size = ByteCount;
			IntPtr* ppA = (IntPtr*)(&pA);
			int offset = 0;
			while(size - offset>=8) {
				if(*(long*)(*ppA+offset) != 0)
					return false;
				offset+=8;
			}
			while(size - offset>0) {
				if(*(byte*)(*ppA+offset) != 0)
					return false;
				offset++;
			}
			return true;
		}
	}
	
	void Main()//LINQpad
	{
		StructHelpers<decimal>.ByteCount.Dump();
		PossiblyUninitialized(0m).Dump();//true
		PossiblyUninitialized(0.0m).Dump();//false
		PossiblyUninitialized(0.0).Dump();//true
		PossiblyUninitialized(-0.0).Dump();//false
		PossiblyUninitialized("").Dump();//false
	}
