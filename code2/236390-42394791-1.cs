        <UserControl...
        <Grid>
            <DataGrid ItemsSource="{Binding MainData.ProjColl}" 
                      AutoGenerateColumns="False"
                      AlternationCount="{ Binding MainData.ProjColl.Count}" >
                <DataGrid.Columns>
                    <!--Columns given here for example-->
                    ...
                    <DataGridTextColumn Header="Project Name" 
                                        Binding="{Binding CMProjectItemDirName}"
                                        IsReadOnly="True"/>
                    ...
                    <DataGridTextColumn Header="Sources Dir" 
                                        Binding="{Binding CMSourceDir.DirStr}"/>
                    ...
                </DataGrid.Columns>
                <!--The problem of the day-->
                <DataGrid.RowHeaderStyle>
                    <Style TargetType="{x:Type DataGridRowHeader}">
                        <Setter Property="Content" 
                         Value="{Binding Path=(ItemsControl.AlternationIndex),
                         RelativeSource={RelativeSource AncestorType=DataGridRow}}"/>
                    </Style>
                </DataGrid.RowHeaderStyle>
            </DataGrid>
        </Grid>
        </UserControl>
