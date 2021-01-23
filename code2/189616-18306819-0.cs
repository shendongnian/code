		/// <summary>
		/// Concatenates MvcHtmlStrings together
		/// </summary>
		public static MvcHtmlString Append(this MvcHtmlString first, params object[] args) {
			return new MvcHtmlString(string.Concat(args));
		}
