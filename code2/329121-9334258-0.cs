    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public static bool IsNullOrEmpty(string value)
        {
          if (value != null)
            return value.Length == 0;
          else
            return true;
        }
    
        /// <summary>
        /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// 
        /// <returns>
        /// true if the <paramref name="value"/> parameter is null or <see cref="F:System.String.Empty"/>, or if <paramref name="value"/> consists exclusively of white-space characters.
        /// </returns>
        /// <param name="value">The string to test.</param>
        public static bool IsNullOrWhiteSpace(string value)
        {
          if (value == null)
            return true;
          for (int index = 0; index < value.Length; ++index)
          {
            if (!char.IsWhiteSpace(value[index]))
              return false;
          }
          return true;
        }
