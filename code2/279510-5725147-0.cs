        public class FormFieldCollection : List<FormField>
        {
            public string FormFieldType { get; set; }
        }
        public class FormField
        {
            public string Name {get;set;}
            public string Type {get;set;}
            public string Value {get;set;}
            public bool IsChecked {get;set;}
        }
        public class FormFieldModel
        {
            public FormFieldCollection PaymentOptions { get; set; }
        }
