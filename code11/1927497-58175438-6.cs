    <!--Style and template for the DataGridRow.-->
    <Style TargetType="{x:Type DataGridRow}">
      <Setter Property="Background" 
              Value="Transparent" />
      <Setter Property="BorderThickness" 
              Value="1"/>
      <Setter Property="SnapsToDevicePixels"
              Value="true" />
      <Setter Property="Validation.ErrorTemplate"
              Value="{x:Null}" />
      <Setter Property="ValidationErrorTemplate">
        <Setter.Value>
          <ControlTemplate>
            <TextBlock Foreground="Red"
                       Margin="2,0,0,0"
                       Text="!"
                       VerticalAlignment="Center" />
          </ControlTemplate>
        </Setter.Value>
      </Setter>
      <Setter Property="Template">
        <Setter.Value>
          <ControlTemplate TargetType="{x:Type DataGridRow}">
            <Border x:Name="DGR_Border"
                    BorderBrush="{TemplateBinding BorderBrush}"
                    BorderThickness="{TemplateBinding BorderThickness}"
                    Background="{TemplateBinding Background}">
              <SelectiveScrollingGrid>
                <SelectiveScrollingGrid.ColumnDefinitions>
                  <ColumnDefinition Width="Auto" />
                  <ColumnDefinition Width="*" />
                </SelectiveScrollingGrid.ColumnDefinitions>
                <SelectiveScrollingGrid.RowDefinitions>
                  <RowDefinition Height="*" />
                  <RowDefinition Height="Auto" />
                </SelectiveScrollingGrid.RowDefinitions>
                <DataGridCellsPresenter Grid.Column="1"
                                        ItemsPanel="{TemplateBinding ItemsPanel}"
                                        SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" />
                <DataGridDetailsPresenter Grid.Column="1"
                                          Grid.Row="1"
                                          Visibility="{TemplateBinding DetailsVisibility}"
                                          SelectiveScrollingGrid.SelectiveScrollingOrientation="{Binding AreRowDetailsFrozen, 
              ConverterParameter={x:Static SelectiveScrollingOrientation.Vertical},
              Converter={x:Static DataGrid.RowDetailsScrollingConverter}, 
              RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" />
                <DataGridRowHeader Grid.RowSpan="2"
                                   SelectiveScrollingGrid.SelectiveScrollingOrientation="Vertical"
                                   Visibility="{Binding HeadersVisibility, 
              ConverterParameter={x:Static DataGridHeadersVisibility.Row}, 
              Converter={x:Static DataGrid.HeadersVisibilityConverter}, 
              RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" />
              </SelectiveScrollingGrid>
            </Border>
            <ControlTemplate.Triggers>
              <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                  <Condition Binding="{Binding RelativeSource={RelativeSource Mode=Self}, Path=IsSelected}"
                             Value="False" />
                  <Condition Binding="{Binding DisplayCat}"
                             Value="0" />
                </MultiDataTrigger.Conditions>
                <Setter Property="BorderBrush"
                        Value="Transparent" />
              </MultiDataTrigger>
              <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                  <Condition Binding="{Binding RelativeSource={RelativeSource Mode=Self}, Path=IsSelected}"
                             Value="False" />
                  <Condition Binding="{Binding DisplayCat}"
                             Value="1" />
                </MultiDataTrigger.Conditions>
                <Setter Property="BorderBrush"
                        Value="Transparent" />
              </MultiDataTrigger>
              <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                  <Condition Binding="{Binding RelativeSource={RelativeSource Mode=Self}, Path=IsSelected}"
                             Value="True" />
                  <Condition Binding="{Binding DisplayCat}"
                             Value="0" />
                </MultiDataTrigger.Conditions>
                <Setter Property="BorderBrush"
                        Value="Crimson" />
              </MultiDataTrigger>
              <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                  <Condition Binding="{Binding RelativeSource={RelativeSource Mode=Self}, Path=IsSelected}"
                             Value="True" />
                  <Condition Binding="{Binding DisplayCat}"
                             Value="1" />
                </MultiDataTrigger.Conditions>
                <Setter Property="BorderBrush"
                        Value="Crimson" />
              </MultiDataTrigger>
            </ControlTemplate.Triggers>
          </ControlTemplate>
        </Setter.Value>
      </Setter>
