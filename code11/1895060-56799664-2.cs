    public class TextFieldMustHaveValue : OneFieldRule {
        public TextFieldMustHaveValue(String tableName, String fieldName) : base(tableName, fieldName) {
            Description = $"Field {FieldName} cannot be empty!";
        }
        protected override String GetErrorMessageIfInvalid(DataRow record) {
            if (String.IsNullOrWhiteSpace(record.Field<String>(FieldName))) {
                return Description;
            }
            return null;
        }
    }
