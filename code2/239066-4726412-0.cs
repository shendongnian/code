    <Application.Resources>
        <ControlTemplate TargetType='{x:Type ListViewItem}' x:Key="MyListViewItemTemplate">
            <Grid>
                <Border CornerRadius="15" Name="mask" Background="White"/>
                <StackPanel Background="Beige">
                    <StackPanel.OpacityMask>
                        <VisualBrush Visual="{Binding ElementName=mask}"/>
                    </StackPanel.OpacityMask>
                    <GridViewRowPresenter Content="{TemplateBinding Content}" Columns="{TemplateBinding GridView.ColumnCollection}"/>
                    <TextBlock Background="LightBlue" Text="{Binding News}" />
                </StackPanel>
            </Grid>
        </ControlTemplate>
    </Application.Resources>
