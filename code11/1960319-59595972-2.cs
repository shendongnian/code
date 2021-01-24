none
System.NotSupportedException: Also fail in IEnumerable member with XmlAttributeAttribute
   at System.Xml.Serialization.XmlSerializationWriterILGen.WriteMember(SourceInfo source, AttributeAccessor attribute, TypeDesc memberTypeDesc, String parent)
   at System.Xml.Serialization.XmlSerializationWriterILGen.WriteStructMethod(StructMapping mapping)
   at System.Xml.Serialization.XmlSerializationWriterILGen.GenerateMethod(TypeMapping mapping)
   at System.Xml.Serialization.XmlSerializationILGen.GenerateReferencedMethods()
   at System.Xml.Serialization.XmlSerializationWriterILGen.GenerateEnd()
   at System.Xml.Serialization.TempAssembly.GenerateRefEmitAssembly(XmlMapping[] xmlMappings, Type[] types, String defaultNamespace)
   at System.Xml.Serialization.TempAssembly..ctor(XmlMapping[] xmlMappings, Type[] types, String defaultNamespace, String location)
   at System.Xml.Serialization.XmlSerializer.GenerateTempAssembly(XmlMapping xmlMapping, Type type, String defaultNamespace, String location)
   at System.Xml.Serialization.XmlSerializer..ctor(Type type, String defaultNamespace)
   at System.Xml.Serialization.XmlSerializer..ctor(Type type)
</blockquote>
Why might this happen?  Well, one difference between `List<AxisExceptionActionEnum>` and `AxisExceptionActionEnumCollection` is that the former implements the old non-generic interfaces [`IList`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist) and `ICollection`, maybe the lack of non-generic access to the collection is causing problems for the serializer?  To test this I implemented `ICollection` for your collection:
    [System.Runtime.InteropServices.ComVisible(true)]
    [System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.AutoDual)]
    public class AxisExceptionActionEnumCollection : IList<AxisExceptionActionEnum>, ICollection
    {
        // Remainder unchanged
        #region ICollection Members
        void ICollection.CopyTo(Array array, int index)
        {
            ((System.Collections.IList)(this.axisExceptionActionEnumField)).CopyTo(array, index);
        }
        int ICollection.Count { get { return Count; } }
        bool ICollection.IsSynchronized { get { return ((System.Collections.IList)(this.axisExceptionActionEnumField)).IsSynchronized; } }
        object ICollection.SyncRoot { get { return ((System.Collections.IList)(this.axisExceptionActionEnumField)).SyncRoot; } }
        #endregion
    }
And the problem resolved itself!  Demo fiddle #3 [here](https://dotnetfiddle.net/NbjSD5).
Notes:
 - It was only necessary to implement the non-generic `ICollection` interface -- not the non-generic `IList`.
 
 - `XmlSerializer` is perfectly happy to serialize your generic-only collection *as long as it is marked with `[XmlElement]` instead of `[XmlAttribute]`*:
    ```
	[System.Runtime.InteropServices.ComVisible(true)]
	[System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.AutoDual)]
	public class RSLogix5000Content
	{
		[XmlElement]
		public AxisExceptionActionEnumCollection CIPAxisExceptionAction { get; set; }
	}
    ```
    Demo fiddle #4 [here](https://dotnetfiddle.net/1BYsyN).
 - Since `ICollection` doesn't even have an `Add(object value)` method, this definitely feels like an `XmlSerializer` bug.  You might want to report an issue to Microsoft, e.g. [here](https://github.com/dotnet/runtime/issues).
 - I was a bit surprised that serializing a collection of enums as an attribute resulted in a space-separated sequence of enum values; nothing in the [docs](https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlattributeattribute?view=netframework-4.8#remarks) suggests this should work.
   But since a `[Flags]` enum is also serialized as a space-separated sequence of enum values, it seems that trying to serialize a list of flag enums as an XML attribute also fails with an inscrutable exception:
    ```
	public class RSLogix5000Content
	{
		[XmlAttribute] public List<AxisExceptionActionEnum>  CIPAxisExceptionAction { get; set; }
	}
	[Flags]
	public enum AxisExceptionActionEnum
	{
		Default = 0,
		Value1 = (1<<0),
		Value2 = (1<<1)
	}
    ```
    <blockquote>
    ```none
Failed with unhandled exception: 
System.InvalidOperationException: There was an error reflecting type 'RSLogix5000Content'.
 ---> System.InvalidOperationException: There was an error reflecting property 'CIPAxisExceptionAction'.
 ---> System.InvalidOperationException: There was an error reflecting type 'AxisExceptionActionEnum'.
 ---> System.FormatException: Index (zero based) must be greater than or equal to zero and less than the size of the argument list.
   at System.Text.StringBuilder.AppendFormatHelper(IFormatProvider provider, String format, ParamsArray args)
   at System.String.FormatHelper(IFormatProvider provider, String format, ParamsArray args)
   at System.String.Format(String format, Object arg0)
   at System.SR.Format(String resourceFormat, Object p1)
   at System.Xml.Serialization.XmlReflectionImporter.ImportEnumMapping(EnumModel model, String ns, Boolean repeats)
    ```
    </blockquote>
   Demo fiddle #5 [here](https://dotnetfiddle.net/jMIBBL).
