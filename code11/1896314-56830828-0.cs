    <Application ...>
        <Application.Resources>
            <ResourceDictionary>
                <Color x:Key="PageBackgroundColor">Yellow</Color>
                <Color x:Key="HeadingTextColor">Black</Color>
                <Color x:Key="NormalTextColor">Blue</Color>
                <Style x:Key="LabelPageHeadingStyle" TargetType="Label">
                    <Setter Property="FontAttributes" Value="Bold" />
                    <Setter Property="HorizontalOptions" Value="Center" />
                    <Setter Property="TextColor" Value="{StaticResource HeadingTextColor}" />
                </Style>
            </ResourceDictionary>
        </Application.Resources>
    </Application>
