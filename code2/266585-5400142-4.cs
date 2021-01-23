	using System.Collections.Generic;
	using System.Linq;
	using System;
	using T=System.String;
	namespace X { public class Y
	{
		public static void Main(string[]args) 
		{
			var content = Sources().FirstOrDefault(c => c); // trick: uses operator bool()
		}
		internal protected struct Content
		{
			public T Value;
			public ContentFrom Mode;
			//
			public static implicit operator bool(Content specimen) { return specimen.Mode!=ContentFrom.None && null!=specimen.Value; }
		}
		private static IEnumerable<Content> Sources()
		{
			// mock
			var Request = new { QueryString = new [] {"id"}.ToDictionary(a => a) };
			if (!String.IsNullOrEmpty(Request.QueryString["id"]))
				yield return new Content { Value = GetContent(Convert.ToInt64(Request.QueryString["id"])), Mode = ContentFrom.Query };
			if (DefaultId != null)
				yield return new Content { Value = GetContent((long) DefaultId), Mode = ContentFrom.Default };
			yield return new Content();
		}
		public enum ContentFrom { None, Query, Default };
		internal static T GetContent(long id) { return "dummy"; }
		internal static readonly long? DefaultId = 42;
	} }
