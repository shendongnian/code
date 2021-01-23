    <Grid>
        <Grid.Resources>
            <PointCollection x:Key="sampleData">
                <Point>10,20</Point>
                <Point>30,40</Point>
                <Point>50,60</Point>
            </PointCollection>
        </Grid.Resources>
        <ListBox ItemsSource="{StaticResource sampleData}">
            <ListBox.ItemContainerStyle>
                <Style TargetType="ListBoxItem">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ListBoxItem">
                                <StackPanel>
                                    <Separator/>
                                    <ContentPresenter/>
                                </StackPanel>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ListBox.ItemContainerStyle>
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding}"/>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
