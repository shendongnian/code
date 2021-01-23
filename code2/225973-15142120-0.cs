        public static class TExtensions
    	{
    		public static string Serialize<T>(this T thisT)
    		{
    			var serializer = new DataContractSerializer(thisT.GetType());
    			using (var writer = new StringWriter())
    			using (var stm = new XmlTextWriter(writer))
    			{
    				serializer.WriteObject(stm, thisT);
    				return writer.ToString();
    			}
    		}
    }
