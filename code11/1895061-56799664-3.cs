    public sealed class Validator {
        //Private Fields
        private Dictionary<String, List<EntityValidationRule>> ruleDict;
        //Constructors
        //The list of all rules we just have somehow...
        public Validator(IEnumerable<EntityValidationRule> rules, StringComparer identifyerComparer) {
            if (rules == null) throw new ArgumentNullException(nameof(rules));
            if (identifyerComparer == null) identifyerComparer = StringComparer.OrdinalIgnoreCase;
            IdentifyerComparer = identifyerComparer;
            ruleDict = new Dictionary<String, List<EntityValidationRule>>(IdentifyerComparer);
            foreach (EntityValidationRule myRule in rules) {
                myRule.Validator = this;
                List<EntityValidationRule> myRules = null;
                if (ruleDict.TryGetValue(myRule.TableName, out myRules)) {
                    myRules.Add(myRule);
                } else {
                    myRules = new List<EntityValidationRule> { myRule };
                    ruleDict.Add(myRule.TableName, myRules);
                }
            }
        }
        //Public Properties
        public StringComparer IdentifyerComparer { get; }
        //Public Methods
        public Boolean IsValid(DataRow record, ref IErrorDetails[] errors) {
            //Check whether the record is null
            if (record == null) {
                errors = new IErrorDetails[] { new ErrorDetails(record, null, "The given record is null!") };
                return false;
            }
            //Loop through every check and invoke them
            List<IErrorDetails> myErrors = null;
            IErrorDetails myError = null;
            foreach (EntityValidationRule myRule in GetRules(record.Table.TableName)) {
                if (myRule.IsValid(record, ref myError)) {
                    if (myErrors == null) myErrors = new List<IErrorDetails>();
                    myErrors.Add(myError);
                }
            }
            //Return true if there are no errors
            if (myErrors == null) return true;
            //Otherwise assign them as result and return false
            errors = myErrors.ToArray();
            return false;
        }
        //Private Methods
        private IEnumerable<EntityValidationRule> GetRules(String tableName) {
            if (ruleDict.TryGetValue(tableName, out List<EntityValidationRule> myRules)) return myRules;
            return Array.Empty<EntityValidationRule>();
        }
    }
