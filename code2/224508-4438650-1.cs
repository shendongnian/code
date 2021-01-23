                <Setter Property="HeaderTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="Auto" />
                                    <ColumnDefinition Width="*" />
                                </Grid.ColumnDefinitions>
                                <Image Grid.Column="0"
                                       Source="{Binding Path=IconPath}" />
                                <TextBlock Grid.Column="1"
                                           Text="{Binding DisplayName}" />
                            </Grid>
                        <DataTemplate />
                    </Setter.Value>
                </Setter>
