        <ComboBox Name="contactsListBox" ItemsSource="{Binding MyList}">
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding ContactListName}"/>
                        <ComboBox ItemsSource="{Binding AggLabels, Converter={StaticResource Conv}}"/>
                    </StackPanel>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
    public class AggLabelsDistictConverter : IValueConverter
    {
        class AggregatedLabelComparer : IEqualityComparer<AggregatedLabel>
        {
            #region IEqualityComparer<AggregatedLabel> Members
            public bool Equals(AggregatedLabel x, AggregatedLabel y)
            {
                return x.Name == y.Name;
            }
            public int GetHashCode(AggregatedLabel obj)
            {
                return obj.Name.GetHashCode();
            }
            #endregion
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is IEnumerable<AggregatedLabel>)
            {
                var list = (IEnumerable<AggregatedLabel>)value;
                return list.Distinct(new AggregatedLabelComparer());
            }}}
