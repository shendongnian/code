        [AttributeUsage(AttributeTargets.Property)]
        public class FieldName : Attribute
        {
            public FieldName(string text)
            {
                this.Text = text;
            }
            public string Text { get; set; }
        }
