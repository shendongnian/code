    public class Person
    {
        [FieldLabel("First name")]
        [ValidationRules(Rules.NotEmpty | Rules.OnlyCharacters)] 
        [FormColumn(1)]
        [FormRow(1)]
        public string FirstName{get;set;}
        [FieldLabel("Last name")]
        [ValidationRules(Rules.NotEmpty | Rules.OnlyCharacters)]
        [FormColumn(2)]
        [FormRow(1)]
        public string LastName{get;set;}
    }
