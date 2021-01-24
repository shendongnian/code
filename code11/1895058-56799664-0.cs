    public abstract class EntityValidationRule {
        //Private Fields
        private Validator validator;
        //Constructors
        public EntityValidationRule(String tableName, IEnumerable<String> affectedFields) {
            TableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
            AffectedFields = affectedFields?.ToArray() ?? Array.Empty<String>();
        }
        //Public Properties
        public String TableName { get; }
        public String[] AffectedFields { get; }
        public virtual String Description { get; protected set; }
        //Public Methods
        public Boolean IsValid(DataRow record, ref IErrorDetails errorDetails) {
            if (record == null) throw new InvalidOperationException("Programming error in Validator.cs");
            if (!Validator.IdentifyerComparer.Equals(record.Table.TableName, TableName)) throw new InvalidOperationException("Programming error in Validator.cs");
            String myError = GetErrorMessageIfInvalid(record);
            if (myError == null) return true;
            errorDetails = CreateErrorDetails(record, myError);
            return false;
        }
        //Protected Properties
        public Validator Validator {
            get {
                return validator;
            }
            internal set {
                if ((validator != null) && (!Object.ReferenceEquals(validator, value))) {
                    throw new InvalidOperationException("An entity validation rule can only be added to a single validator!");
                }
                validator = value;
            }
        }
        //Protected Methods
        protected virtual IErrorDetails CreateErrorDetails(DataRow record, String errorMessage) {
            return new ErrorDetails(record, this, errorMessage);
        }
        protected abstract String GetErrorMessageIfInvalid(DataRow record);
    }
