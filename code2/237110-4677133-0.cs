    <Grid>
        <charting:Chart>
            <charting:Chart.Palette>
                <visualizationToolkit:ResourceDictionaryCollection>
                    <ResourceDictionary>
                        <Style x:Key="DataPointStyle" TargetType="Control">
                            <Setter Property="Background" Value="MistyRose"/>
                        </Style>
                    </ResourceDictionary>
                    <ResourceDictionary>
                        <Style x:Key="DataPointStyle" TargetType="Control">
                            <Setter Property="Background" Value="AliceBlue"/>
                        </Style>
                    </ResourceDictionary>
                </visualizationToolkit:ResourceDictionaryCollection>
            </charting:Chart.Palette>
            <charting:AreaSeries Title="Series 1"/>
            <charting:AreaSeries Title="Series 2"/>
        </charting:Chart>
    </Grid>
