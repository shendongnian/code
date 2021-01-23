    public class Person
    {
        [FieldLabel("First name")]
        [FormColumn(1)]
        [FormRow(1)]
        public string FirstName{get;set;}
        [FieldLabel("Last name")]
        [FormColumn(2)]
        [FormRow(1)]
        public string LastName{get;set;}
    }
