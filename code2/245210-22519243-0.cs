     SqlParameter @TableName = new SqlParameter()
            {
                ParameterName = "@TableName",
                DbType = DbType.String,
                Value = "Trans"
            };
    SqlParameter @FieldName = new SqlParameter()
            {
                ParameterName = "@FieldName",
                DbType = DbType.String,
                Value = "HLTransNbr"
            };
    object[] parameters = new object[] { @TableName, @FieldName };
    List<Sample> x = this.Database.SqlQuery<Sample>("usp_NextNumberBOGetMulti @TableName, @FieldName", parameters).ToList();
    public class Sample
    {
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public int NextNum { get; set; }
    }
