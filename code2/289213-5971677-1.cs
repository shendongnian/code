    using System.Data.Objects.DataClasses;
    public partial class YourObjectContext
    {
        /// <summary>
        ///     This method exists for use in LINQ queries,
        ///     as a stub that will be converted to a SQL CAST statement.
        /// </summary>
        [EdmFunction("YourModel", "ParseDouble")]
        public static double ParseDouble(string stringvalue)
        {
            return Double.Parse(stringvalue);
        }
    }
