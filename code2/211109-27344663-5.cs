        ///<summary>
        /// Use "string".FormatIt(...) instead of string.Format("string, ...)
        /// Use {nl} in text to insert Environment.NewLine 
        ///</summary>
        ///<exception cref="ArgumentNullException">If format is null</exception>
        [StringFormatMethod("format")]
        public static string FormatIt(this string format, params object[] args)
        {
            if (format == null) throw new ArgumentNullException("format");
            return string.Format(format.Replace("{nl}", Environment.NewLine), args);
        }
