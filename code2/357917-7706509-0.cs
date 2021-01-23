       <Grid>
            <Grid.Resources>
                <l:MyConverter x:Key="MyConverter" />
            </Grid.Resources>
    
            <ComboBox VerticalAlignment="Center">
                <ComboBoxItem Content="Content Placeholder One" />
                <ComboBoxItem Content="Content Placeholder Two" />
                <ComboBoxItem Content="Content Placeholder Three" />
                <ComboBox.ItemContainerStyle>
                    <Style TargetType="{x:Type ComboBoxItem}">
                        <Setter Property="Tag">
                            <Setter.Value>
                                <MultiBinding Converter="{StaticResource MyConverter}">
                                    <Binding RelativeSource="{RelativeSource Self}" Path="IsHighlighted" />
                                    <Binding />
                                </MultiBinding>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </ComboBox.ItemContainerStyle>
            </ComboBox>
        </Grid>
