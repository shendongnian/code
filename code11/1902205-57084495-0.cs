    ... xmlns:sys="clr-namespace:System;assembly=mscorlib"
    <ItemsControl ItemsSource="{Binding Parameters}">
        <ItemsControl.Resources>
            <DataTemplate DataType="{x:Type sys:Boolean}">
                <Checkbox IsChecked="{Binding}" />
            </DataTemplate>
            <DataTemplate DataType="{x:Type sys:String}">
                 <TextBlock Text="{Binding}" />
            </DataTemplate>
        </ItemsControl.Resources>
        <ItemsControl.ItemTemplate>
             <DataTemplate>
                 <StackPanel Orientation="Horizontal">
                     <TextBlock Text="{Binding Title}" />
                     <ContentPresenter Content="{Binding Value}" />
                 </StackPanel>
             </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
