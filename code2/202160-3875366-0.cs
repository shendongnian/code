        /// <summary>
        /// Pluralises the singular form word specified.
        /// </summary>
        /// <param name="this">The singular form.</param>
        /// <param name="count">The count.</param>
        /// <returns>The word, pluralised if necessary.</returns>
        public static string Pluralise(this string @this, long count)
        {
            return (count == 1) ? @this :
                                  Pluralise(@this);
        }
        /// <summary>
        /// Pluralises the singular form word specified.
        /// </summary>
        /// <param name="this">The singular form word.</param>
        /// <returns>The plural form.</returns>
        public static string Pluralise(this string @this)
        {
            return Inflector.Pluralize(@this);
        }
        /// <summary>
        /// Singularises the plural form word.
        /// </summary>
        /// <param name="this">The plural form word.</param>
        /// <returns>Th singular form.</returns>
        public static string Singularise(this string @this)
        {
            return Inflector.Singularize(@this);
        }
