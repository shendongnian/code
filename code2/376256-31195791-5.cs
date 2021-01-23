		/// <summary>
		/// Writes this XML to string while allowing invalid XML chars to either be
		/// simply removed during the write process, or else encoded into entities, 
		/// instead of having an exception occur, as the standard XmlWriter.Create 
		/// XmlWriter does (which is the default writer used by XElement).
		/// </summary>
		/// <param name="xml">XElement.</param>
		/// <param name="deleteInvalidChars">True to have any invalid chars deleted, else they will be entity encoded.</param>
		/// <param name="indent">Indent setting.</param>
		/// <param name="indentChar">Indent char (leave null to use default)</param>
		public static string ToStringIgnoreInvalidChars(this XElement xml, bool deleteInvalidChars = true, bool indent = true, char? indentChar = null)
		{
			if (xml == null) return null;
			StringWriter swriter = new StringWriter();
			using (XmlTextWriterIgnoreInvalidChars writer = new XmlTextWriterIgnoreInvalidChars(swriter, deleteInvalidChars)) {
				// -- settings --
				// unfortunately writer.Settings cannot be set, is null, so we can't specify: bool newLineOnAttributes, bool omitXmlDeclaration
				writer.Formatting = indent ? Formatting.Indented : Formatting.None;
				if (indentChar != null)
					writer.IndentChar = (char)indentChar;
			
				// -- write --
				xml.WriteTo(writer); 
			}
			return swriter.ToString();
		}
