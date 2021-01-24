    <xcad:DockingManager>   
      <xcad:DockingManager.Resources>
        <Style TargetType="xcad:AnchorablePaneTitle">
          <Setter Property="Template">
            <Setter.Value>
              <ControlTemplate TargetType="xcad:AnchorablePaneTitle">
                <Border
                     Background="{TemplateBinding Background}" 
                     BorderBrush="{TemplateBinding BorderBrush}" 
                     BorderThickness="{TemplateBinding BorderThickness}">
                  <Grid>
                    <Grid.ColumnDefinitions>
                      <ColumnDefinition Width="*" />
                      <ColumnDefinition Width="Auto" />
                    </Grid.ColumnDefinitions>
                    <xcad:DropDownControlArea
                      DropDownContextMenu="{Binding Model.Root.Manager.AnchorableContextMenu, RelativeSource={RelativeSource TemplatedParent}}"
                      DropDownContextMenuDataContext="{Binding Path=LayoutItem, RelativeSource={RelativeSource TemplatedParent}}">
                      <ContentPresenter Content="{Binding Model, RelativeSource={RelativeSource TemplatedParent}}"
                        ContentTemplate="{Binding Model.Root.Manager.AnchorableTitleTemplate, RelativeSource={RelativeSource TemplatedParent}}"
                        ContentTemplateSelector="{Binding Model.Root.Manager.AnchorableTitleTemplateSelector, RelativeSource={RelativeSource TemplatedParent}}" />
                    </xcad:DropDownControlArea>
                    <Button x:Name="PART_HidePin"
                      Grid.Column="1"
                      Focusable="False"
                      Style="{StaticResource {x:Static ToolBar.ButtonStyleKey}}"
                      Command="{Binding Path=LayoutItem.HideCommand, RelativeSource={RelativeSource TemplatedParent}}"
                      ToolTip="{x:Static avalonDockProperties:Resources.Anchorable_BtnClose_Hint}">
                      <Border Background="White">
                        <Image Source="/Xceed.Wpf.AvalonDock;component/Themes/Generic/Images/PinClose.png"/>
                      </Border>
                    </Button>
                  </Grid>
                </Border>
                <ControlTemplate.Triggers>
                  <DataTrigger Binding="{Binding Model.CanClose, RelativeSource={RelativeSource Mode=Self}}"
                         Value="True">
                    <Setter Property="Command"
                      TargetName="PART_HidePin"
                      Value="{Binding Path=LayoutItem.CloseCommand, RelativeSource={RelativeSource TemplatedParent}}" />
                    <Setter Property="ToolTip"
                      TargetName="PART_HidePin"
                      Value="{x:Static avalonDockProperties:Resources.Document_Close}" />
                  </DataTrigger>
                </ControlTemplate.Triggers>
              </ControlTemplate>
            </Setter.Value>
          </Setter>
        </Style>
      </xcad:DockingManager.Resources>
    </xcad:DockingManager>
