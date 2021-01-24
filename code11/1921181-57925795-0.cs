public static readonly BindableProperty TestItemsProperty =
            BindableProperty.Create(
                propertyName: "TestItems",
                returnType: typeof(ObservableCollection<TestModel>),
                declaringType: typeof(TestControl ),
                propertyChanged: OnEventNameChanged);
static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
{
            Console.WriteLine(newValue.ToString());
            var control = (View1)bindable;
            control.lv.ItemsSource = newValue as ObservableCollection<TestModel>;
}
And remove the line from the constructor 
BindingContext = this;
