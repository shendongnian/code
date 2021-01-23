		private const string INDENT_STRING = "  ";
		/// <summary>
		/// Increase the indent level.
		/// </summary>
		public void IncreaseIndent() {
			// Increase indent
			indentLevel++;
			indentBuffer.Append(INDENT_STRING);
			// If new line already started, insert another indent at the beginning
			if (!useIndent) contentBuffer.Insert(0, INDENT_STRING);
		}
		/// <summary>
		/// Decrement the indent level.  
		/// </summary>
		public void DecreaseIndent() {
			// Only decrease the indent to zero.
			if (indentLevel > 0) {
				indentLevel--;
      
				// Remove an indent from the string, if applicable
				if (indentBuffer.Length != 0) {
					indentBuffer.Remove(indentBuffer.Length - INDENT_STRING_LENGTH, INDENT_STRING_LENGTH);
				}
			}
		}
