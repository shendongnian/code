    <chartingToolkit:Chart x:Name="ExampleChart">
        <chartingToolkit:PieSeries>
            <chartingToolkit:PieSeries.ItemsSource >
                <toolkit:ObjectCollection>
                    <sys:Double>1</sys:Double>
                    <sys:Double>2.3</sys:Double>
                    <sys:Double>3.5</sys:Double>
                    <sys:Double>5</sys:Double>
                </toolkit:ObjectCollection>
            </chartingToolkit:PieSeries.ItemsSource >
            <chartingToolkit:PieSeries.Palette>
                <visualizationToolkit:ResourceDictionaryCollection>
                <ResourceDictionary>
                    <Style x:Key="DataPointStyle" TargetType="Control">
                        <Setter Property="Background" Value="Red"/>
                    </Style>
                </ResourceDictionary>
                <ResourceDictionary>
                    <Style x:Key="DataPointStyle" TargetType="Control">
                        <Setter Property="Background" Value="Green"/>
                    </Style>
                </ResourceDictionary>
                <ResourceDictionary>
                    <Style x:Key="DataPointStyle" TargetType="Control">
                        <Setter Property="Background" Value="Blue"/>
                    </Style>
                </ResourceDictionary>
                </visualizationToolkit:ResourceDictionaryCollection>
            </chartingToolkit:PieSeries.Palette>
        </chartingToolkit:PieSeries >
    </chartingToolkit:Chart >
