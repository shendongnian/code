             <Grid>
                <StackPanel>
                    <GridViewRowPresenter DockPanel.Dock="Bottom"
                                  Content="Sum"
                                  Columns="{Binding ElementName=OverviewGridView, Path=Columns}">
                    </GridViewRowPresenter>
                    <ListView Margin="0,15"
                      HorizontalAlignment="Stretch"
                      ItemsSource="{Binding DataList}">
                        <ListView.View>
                            <GridView x:Name="OverviewGridView">
                                <GridViewColumn DisplayMemberBinding="{Binding Date, StringFormat=dd.MM.yyyy}" Header="Date"/>
                                <GridViewColumn DisplayMemberBinding="{Binding LicenseCount}" Header="Licenses"/>
                                <GridViewColumn DisplayMemberBinding="{Binding ScansCount}" Header="Scans"/>
                            </GridView>
                        </ListView.View>
                    </ListView>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="{Binding ElementName=OverviewGridView, Path=Columns[0].ActualWidth}"/>
                            <ColumnDefinition Width="{Binding ElementName=OverviewGridView, Path=Columns[1].ActualWidth}"/>
                            <ColumnDefinition Width="{Binding ElementName=OverviewGridView, Path=Columns[2].ActualWidth}"/>
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="Summe" Grid.Column="0"/>
                        <TextBlock Text="{Binding DataList, FallbackValue=0,Converter={StaticResource Summierer}, ConverterParameter=1}" Grid.Column="1"/>
                        <TextBlock Text="{Binding DataList, FallbackValue=0,Converter={StaticResource Summierer}, ConverterParameter=2}" Grid.Column="2"/>
                    </Grid>
                </StackPanel>
            </Grid>
