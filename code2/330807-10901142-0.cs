    <Style x:Key="listBoxAutoFill" TargetType="ListBoxItem">
       <Setter Property="Template">
          <Setter.Value>
             <ControlTemplate TargetType="{x:Type ListBoxItem}">
                <Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}"
                   BorderThickness="{TemplateBinding BorderThickness}"
                   Background="{TemplateBinding Background}" 
                   Padding="{TemplateBinding Padding}" SnapsToDevicePixels="true">
                   <ContentPresenter HorizontalAlignment="Stretch"
                      VerticalAlignment="Stretch" 
                      SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" />
                </Border>
                <ControlTemplate.Triggers>
                   <Trigger Property="IsSelected" Value="true">
                      <Setter Property="Background" TargetName="Bd" 
                         Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                      <Setter Property="Foreground" 
                         Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}"/>
                   </Trigger>
                   <MultiTrigger>
                      <MultiTrigger.Conditions>
                         <Condition Property="IsSelected" Value="true"/>
                         <Condition Property="Selector.IsSelectionActive" Value="false"/>
                      </MultiTrigger.Conditions>
                      <Setter Property="Background" TargetName="Bd" 
                         Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}"/>
                      <Setter Property="Foreground" 
                         Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
                   </MultiTrigger>
                   <Trigger Property="IsEnabled" Value="false">
                      <Setter Property="Foreground" 
                         Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                   </Trigger>
                </ControlTemplate.Triggers>
             </ControlTemplate>
          </Setter.Value>
       </Setter>
    </Style>
