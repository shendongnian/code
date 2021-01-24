public class Foo : PropertyChangedBase
{
        private string property1;
        private string property2;
        private int id;
        public int Id
        {
            get => id; 
            set
            {
                id = value;
                NotifyOfPropertyChange(nameof(Id));
            }
        }
        public string Property1
        {
            get => property1; 
            set
            {
                property1 = value;
                NotifyOfPropertyChange(nameof(Property1));
            }
        }
        public string Property2
        {
            get => property2; 
            set
            {
                property2 = value;
                NotifyOfPropertyChange(nameof(property2));
            }
        }
}
Now you could use the binding to the individual property of the Custom Object.
<TextBox Text="{Binding FooInstance.Property2}"></TextBox>
