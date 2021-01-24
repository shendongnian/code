    <Grid x:Name="grdPages" DataContext={Binding}>
    <ContentControl >
            <ContentControl.Style>
                <Style TargetType="{x:Type ContentControl}">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=grdPages, Path=DataContext.CurrentPage, NotifyOnSourceUpdated=True, UpdateSourceTrigger=PropertyChanged}" Value="0">
                            <Setter Property="ContentTemplate" Value="{StaticResource DTLoginView}"/>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding ElementName=grdPages, Path=DataContext.CurrentPage, NotifyOnSourceUpdated=True, UpdateSourceTrigger=PropertyChanged}" Value="1">
                            <Setter Property="ContentTemplate" Value="{StaticResource DTPageOne}"/>
                        </DataTrigger>
                   </Style.Triggers>
                </Style>
            </ContentControl.Style>                
        </ContentControl>
