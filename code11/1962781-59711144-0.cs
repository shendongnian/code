    public class FunctionConverter : IValueConverter
    {
        public string FunctionName { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.GetType().GetMethod(FunctionName).Invoke(value, (object[])parameter);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
And here's an example of how you might use it:
MainWindow.xaml.cs:
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            TestInstance = new Test();
            InitializeComponent();
        }
                
        public Test TestInstance { get; set; }
    }
    public class Test
    {
        public string Foo(string bar)
        {
            return bar;
        }
    }
MainWindow.xaml:
    <Grid>
        <Grid.Resources>
            <KHS:FunctionConverter x:Key="FuncCon" FunctionName="Foo"/>
        </Grid.Resources>
        <TextBlock>
            <TextBlock.Text>
                <Binding Path="TestInstance" Converter="{StaticResource FuncCon}">
                    <Binding.ConverterParameter>
                        <x:Array Type="sys:Object">
                            <sys:String>Hello World</sys:String>
                        </x:Array>
                    </Binding.ConverterParameter>
                </Binding>
            </TextBlock.Text>
        </TextBlock>
    </Grid>
You declare the converter as a resource, just like you did with the `ObjectDataProvider`, and set `FunctionName` to the name of the function you want to call. The converter then uses [`MethodInfo.Invoke(Object, Object[])`](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.methodbase.invoke?view=netframework-4.8#System_Reflection_MethodBase_Invoke_System_Object_System_Object___) to run that function and returns the result.
You pass parameters for the function via the binding's `ConverterParameter` property, which would let you potentially pass different values for different items in your list. In the example, I pass the string `"Hello World"` to the function `Foo`, which just returns exactly what was passed.
A few final notes: This converter only works one way. The converter as provided doesn't check for `null` and has no handling in place for when `FunctionName` is not found. Using a binding like this doesn't allow for update notifications like a dependency property would provide.
