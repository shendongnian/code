    <ItemsControl ItemsSource="{Binding Root.Elements[Person]}"
                  Grid.IsSharedSizeGroup="True">
        <ItemsControl.Resources>
            <DataTemplate DataType="Person">
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition SharedSizeGroup="NameColumn"/>
                        <ColumnDefinition SharedSizeGroup="AgeColumn" />
                    </Grid.ColumnDefinitions>
                    <TextBox Text="{Binding Path=Attribute[Name].Value}" />
                    <TextBox Text="{Binding Path=Attribute[Age].Value}"
                             Grid.Column="1"/>
                </Grid>
            </DataTemplate>
        </ItemsControl.Resources>
    </ItemsControl>
