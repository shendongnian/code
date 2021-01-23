    <toolkit:DataGrid x:Name="MyDataGrid"
          IsReadOnly="True"
          AutoGenerateColumns="False">
      <toolkit:DataGrid.Resources>
        <local:EqualityConverter x:Key="EqualityConverter"/>
        <Style TargetType="{x:Type toolkit:DataGridColumnHeader}">
          <Style.Triggers>
            <DataTrigger Value="True">
              <DataTrigger.Binding>
                <MultiBinding Converter="{StaticResource EqualityConverter}">
                   <Binding Path="CurrentCell.Column.Header"
                      RelativeSource="{RelativeSource
                         AncestorType={x:Type toolkit:DataGrid}}"/>
                    <Binding Path="Content"
                      RelativeSource="{RelativeSource Self}"/>
                </MultiBinding>
              </DataTrigger.Binding>
              <Setter Property="Background" Value="Red"/>
            </DataTrigger>
          </Style.Triggers>
        </Style>
      </toolkit:DataGrid.Resources>
      <toolkit:DataGrid.Columns>
        <toolkit:DataGridTextColumn Header="Key"
               Binding="{Binding Key, Mode=OneWay}"></toolkit:DataGridTextColumn>
        <toolkit:DataGridTextColumn Header="Value"
               Binding="{Binding Value, Mode=OneWay}"></toolkit:DataGridTextColumn>
      </toolkit:DataGrid.Columns>
    </toolkit:DataGrid>
