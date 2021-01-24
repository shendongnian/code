    <UserControl.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary>
                    <Style x:Key="ColorfulButtonStyle" TargetType="Button">
                        <Style.Triggers>
                            <Trigger Property="IsPressed" Value="True">
                                <Setter Property="Background" Value="Pink"/>
                            </Trigger>
                            <Trigger Property="IsPressed" Value="False">
                                <Setter Property="Background" Value="Blue"/>
                            </Trigger>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter Property="Background" Value="Purple"/>
                            </Trigger>
                            <Trigger Property="IsMouseOver" Value="False">
                                <Setter Property="Background" Value="green"/>
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                    <ControlTemplate x:Key="EmptyButtonTemplate" TargetType="Button">
                        <Border Background="{TemplateBinding Background}" BorderThickness="0" HorizontalAlignment="Stretch" VerticalAlignment="Stretch">
                            <ContentPresenter/>
                        </Border>
                    </ControlTemplate>
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </UserControl.Resources>
        <Button Template="{StaticResource EmptyButtonTemplate}" Style="{StaticResource ColorfulButtonStyle}" Width="30" Height="30" >
            <Ellipse HorizontalAlignment="Stretch" VerticalAlignment="Stretch" Fill="Black"/>
            <!--Replace the ellipse with the shape you like, defined as a control in code or in xaml-->
        </Button>
