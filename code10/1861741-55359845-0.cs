xml
<SolidColorBrush x:Key="BackGroundColorBrush" Color="DeepPink" />
<Style x:Key="MetroComboBoxItem" TargetType="ComboBoxItem">
        <Setter Property="Background" Value="{DynamicResource WhiteBrush}" />
        <Setter Property="BorderThickness" Value="0" />
        <Setter Property="Controls:ItemHelper.ActiveSelectionBackgroundBrush" Value="{DynamicResource AccentColorBrush}" />
        <Setter Property="Controls:ItemHelper.ActiveSelectionForegroundBrush" Value="{DynamicResource AccentSelectedColorBrush}" />
        <Setter Property="Controls:ItemHelper.DisabledForegroundBrush" Value="{DynamicResource GrayNormalBrush}" />
        <Setter Property="Controls:ItemHelper.DisabledSelectedBackgroundBrush" Value="{DynamicResource GrayBrush7}" />
        <Setter Property="Controls:ItemHelper.DisabledSelectedForegroundBrush" Value="{DynamicResource AccentSelectedColorBrush}" />
        <Setter Property="Controls:ItemHelper.HoverBackgroundBrush" Value="{DynamicResource AccentColorBrush3}" />
        <Setter Property="Controls:ItemHelper.HoverSelectedBackgroundBrush" Value="{DynamicResource AccentColorBrush}" />
        <Setter Property="Controls:ItemHelper.SelectedBackgroundBrush" Value="{DynamicResource AccentColorBrush2}" />
        <Setter Property="Controls:ItemHelper.SelectedForegroundBrush" Value="{DynamicResource AccentSelectedColorBrush}" />
        <Setter Property="Foreground" Value="{DynamicResource TextBrush}" />
        <Setter Property="HorizontalContentAlignment" Value="Left" />
        <Setter Property="MinHeight" Value="22" />
        <Setter Property="Padding" Value="2" />
        <Setter Property="SnapsToDevicePixels" Value="True" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="ComboBoxItem">
<--here is what you need to change-->
                    <Grid Background="{DynamicResource BackGroundColorBrush}" RenderOptions.ClearTypeHint="{TemplateBinding RenderOptions.ClearTypeHint}">
                        <Border x:Name="Border"
                                Background="{TemplateBinding Background}"
                                BorderBrush="{TemplateBinding BorderBrush}"
                                BorderThickness="{TemplateBinding BorderThickness}"
                                SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" />
                        <Grid Margin="{TemplateBinding BorderThickness}">
                            <ContentPresenter x:Name="contentPresenter"
                                              Margin="{TemplateBinding Padding}"
                                              HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                              VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                              SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" />
                        </Grid>
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsSelected" Value="True">
                            <Setter Property="Foreground" Value="{Binding RelativeSource={RelativeSource Self}, Path=(Controls:ItemHelper.SelectedForegroundBrush), Mode=OneWay}" />
                            <Setter TargetName="Border" Property="Background" Value="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=(Controls:ItemHelper.SelectedBackgroundBrush), Mode=OneWay}" />
                        </Trigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsSelected" Value="True" />
                                <Condition Property="Selector.IsSelectionActive" Value="True" />
                            </MultiTrigger.Conditions>
                            <Setter Property="Foreground" Value="{Binding RelativeSource={RelativeSource Self}, Path=(Controls:ItemHelper.ActiveSelectionForegroundBrush), Mode=OneWay}" />
                            <Setter TargetName="Border" Property="Background" Value="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=(Controls:ItemHelper.ActiveSelectionBackgroundBrush), Mode=OneWay}" />
                        </MultiTrigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsMouseOver" Value="True" />
                                <Condition Property="IsSelected" Value="True" />
                            </MultiTrigger.Conditions>
                            <Setter TargetName="Border" Property="Background" Value="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=(Controls:ItemHelper.HoverSelectedBackgroundBrush), Mode=OneWay}" />
                        </MultiTrigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsMouseOver" Value="True" />
                                <Condition Property="IsSelected" Value="False" />
                            </MultiTrigger.Conditions>
                            <Setter TargetName="Border" Property="Background" Value="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=(Controls:ItemHelper.HoverBackgroundBrush), Mode=OneWay}" />
                        </MultiTrigger>
                        <Trigger Property="IsEnabled" Value="False">
                            <Setter Property="Foreground" Value="{Binding RelativeSource={RelativeSource Self}, Path=(Controls:ItemHelper.DisabledForegroundBrush), Mode=OneWay}" />
                            <Setter TargetName="Border" Property="Background" Value="{Binding RelativeSource={RelativeSource Self}, Path=(Controls:ItemHelper.DisabledBackgroundBrush), Mode=OneWay}" />
                        </Trigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsEnabled" Value="False" />
                                <Condition Property="IsSelected" Value="True" />
                            </MultiTrigger.Conditions>
                            <Setter Property="Foreground" Value="{Binding RelativeSource={RelativeSource Self}, Path=(Controls:ItemHelper.DisabledSelectedForegroundBrush), Mode=OneWay}" />
                            <Setter TargetName="Border" Property="Background" Value="{Binding RelativeSource={RelativeSource Self}, Path=(Controls:ItemHelper.DisabledSelectedBackgroundBrush), Mode=OneWay}" />
                        </MultiTrigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <Setter Property="VerticalContentAlignment" Value="Center" />
        <Style.Triggers>
            <Trigger Property="IsVisible" Value="True">
                <Setter Property="RenderOptions.ClearTypeHint" Value="{Binding Path=(RenderOptions.ClearTypeHint), FallbackValue=Auto, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ComboBox}}}" />
            </Trigger>
        </Style.Triggers>
    </Style>
