    public class TestClass
    {
        static TestClass()
        {
            ChoiseData = new List<string>();
            ChoiseData.Add("Yes");
            ChoiseData.Add("No");
            ChoiseData.Add("Maybe");
        }
        public static List<string> ChoiseData
        {
            get;
            set;
        }
        //...
    }
    <local:TestClass x:Key="TestClass" />
    <DataGridComboBoxColumn Header="Choise_StaticList"
                            SelectedValueBinding="{Binding SelectedChoise}"
                            ItemsSource="{Binding Source={StaticResource TestClass}, Path=ChoiseData}"/>
