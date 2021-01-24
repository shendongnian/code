<StackLayout x:Name="MyStackLayout"
             Grid.Row="5"
             Grid.RowSpan="{Binding MyRowSpanValue, Source={x:Reference Page}}"
             Grid.Column="0">
        <!-- labels/buttons are added here in code-behind -->
</StackLayout>
**Not using a ViewModel**
In your page constructor, set the `BindingContext=this;` and then the xaml/page will look to your code behind for the **MyRowSpanValue** property.
public YourConstructor()
{
    BindingContext = this; // Code behind will be binding context for XAML
}
When you want to change the value of the property (**used for both situations**)
public int MyRowSpanValue { get; set; }
// When you want to change the MyRowSpanProperty
public void ChangeTheValue()
{
    MyRowSpanValue = 3; // Or whatever value you are wanting
    OnPropertyChanged(nameof(MyRowSpanValue));
}
