    public abstract class OneFieldRule : EntityValidationRule {
        public OneFieldRule(String tableName, String fieldName) : base(tableName, new String[] { fieldName }) {
        }
        protected String FieldName => AffectedFields[0];
    }
