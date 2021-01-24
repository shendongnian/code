    public static class EntityFrameworkCoreValueConverters
    {
        /// <summary>
        /// converts values stored in the database as VARCHAR to a nullable bool
        /// handles "TRUE", "FALSE", or DBNULL
        /// </summary>
        public static ValueConverter<bool?, string> dbVarCharNullableToBoolNullableConverter = new ValueConverter<bool?, string>(
            v => v == true ? "TRUE" : v == false ? "FALSE" : null,
            v => v.ToUpper() == "TRUE" ? true : false
        );
    }
