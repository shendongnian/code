	/// <summary>
	/// 
	/// </summary>
	public class Serializer : ISerializer<MyClass, EmptyParameters>
	{
		#region ISerializer<MyClass,EmptyParameters> Members
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Expression<Serializer<MyClass, EmptyParameters>> GetSerializer()
		{
			return (op, obj, par) => Statement.Start(fl => fl
				.Serialize(obj.Version)
				// Static objects can be serialized/deserialized.
				.Serialize(MyClass.StaticReadonlyInts1, typeof(FixedLength<>))
				// So can readonly collections.
				.Serialize(obj.ReadonlyInts1, typeof(FixedLength<>))
				// Both array and List<> (and Dictionary<,>, and SortedDictionary<,>, and
				// many other types of collections)
				////.Serialize(obj.ReadonlyList1)
				.Serialize(obj.ReadonlyList1, typeof(VariableLengthByte<>))
				////// Readonly fields can be serialized/deserialized.
				////// Sadly you can't Dump() serializers that replace read only fields
				////// (replace is the keyword here, readonly int X is a no-no, 
				////// readonly List<int> X is a yes, readonly int[] X is a yes if it's 
				////// FixedLength<>.
				////.Serialize(obj.ReadonlyInt1)
				.Serialize(obj.Bool1)
				.Serialize(obj.Int2)
				// This will be serialized/deserialized only if obj.Version != 0
				// It's only an example of what you can do. You can use the full power of
				// FluentStatement, and remember that if instead of EmptyParameters you
				// had used another class as the parameters, you could have manipulated it
				// through the par object, so par.Version for example.
				.If(obj.Version != 0, fl.Serialize(obj.Int3))
				// This if(s) depend on the operation that is being done
				// (serialization/deserialization/size)
				.If(op == Operation.Serialize, fl.Serialize(obj.Int2))
				.If(op == Operation.Deserialize, fl.Serialize(obj.Int3))
				.Serialize(obj.Short1)
				// Tuples are supported.
				.Serialize(obj.Tuple1)
				// Arrays need to have the length prepended. There are helpers for this.
				// The default helper can be specified in the Serializer<T> constructor and
				// will be used if the field serializer isn't specified.
				////.Serialize(obj.Ints1)
				// Or you can specify it:
				.Serialize(obj.Ints2, typeof(VariableLengthByte<>))
				.Serialize(obj.Ints3, typeof(VariableLengthByte<int[]>))
				// Nullable types are supported
				.Serialize(obj.NullableInt1, typeof(Nullable<int>))
				////.Serialize(obj.NullableInt2)
				// But note that you could even use the Optional<> with value types,
				// usefull for example if you have to use a modifier that is a class
				// (like VariableLengthInt32 for example)
				.Serialize(obj.NullableInt1, typeof(Optional<int>))
				.Serialize(obj.NullableInt2, typeof(Optional<>))
				// So are "optional" objects (fields that can be null)
				// (Note that here if we wanted to specify the helper, we would have
				// to use typeof(Optional<VariableLengthByte<int>>)
				.Serialize(obj.OptionalInts1, typeof(Optional<VariableLengthInt32<int[]>>))
				.Serialize(obj.OptionalInts2, typeof(Optional<>))
				.Serialize(obj.OptionalList1, typeof(Optional<VariableLengthInt32<List<int>>>))
				.Serialize(obj.OptionalList2, typeof(Optional<>))
				// You can serialize a DateTime as the full .NET value
				.Serialize(obj.DateTime1)
				// Or, for example, as an Unix datetime (32 or 64 bits)
				.Serialize(obj.DateTime2, typeof(UnixDateTime<int>))
				.Serialize(obj.Float1)
				.Serialize(obj.Double1)
				.Serialize(obj.Decimal1)
				.Serialize(obj.TimeSpan1)
				// For strings it's a little more complex. There are too many combinations 
				// of possible formats (encoding x string length * (use char or byte length))
				// At this time there isn't any helper for C strings (null terminated strings).
				// You have to "manually" register you string formats.
				.Serialize(obj.String1, typeof(Program.MyUtf8VariableLengthInt32String))
				.Serialize(obj.String2, typeof(Program.MyAsciiVariableLengthInt32String))
				.Serialize(obj.String3, typeof(Program.MyUnicodeVariableLengthInt32String))
				// Chain serializing the base class can be done in this way
				.Serialize(obj, typeof(MySimpleClass))
				// This is only to make it easy to add new serialization fields. The last ) is
				// "attached" to the .Empty and doesn't need to be moved.
				.Empty());
		}
		#endregion
	}
