       <Window.Resources>      
        <TextBox x:Key="SelectionTarget"
                 Text="{Binding Tag.SelectedText,
                                RelativeSource={RelativeSource Self},
                                Mode=TwoWay,
                                UpdateSourceTrigger=Explicit}" />
      </Window.Resources>
 
      <StackPanel>
         <ListBox>
            <ListBox.ItemsSource>
                <x:Array Type="{x:Type System:String}">
                    <System:String>Test String 1</System:String>
                    <System:String>Test String 2</System:String>
                    <System:String>Test String 3</System:String>
                </x:Array>
            </ListBox.ItemsSource>
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <TextBox Name="SelectionSource"
                             Text="{Binding Path=., Mode=TwoWay}" 
                             Tag="{StaticResource SelectionTarget}"
                             SelectionChanged="SelectionSource_SelectionChanged" />
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
        <ContentControl Content="{StaticResource SelectionTarget}">           
        </ContentControl>
    </StackPanel>
