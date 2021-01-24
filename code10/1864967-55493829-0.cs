    <Style TargetType="ComboBox">
        <Setter Property="Text" Value="{Binding Name, UpdateSourceTrigger=Explicit}"/>
        <Style.Triggers>
            <DataTrigger Binding="{Binding trigger}" Value="LostFocus">
                <Setter Property="Text" Value="{Binding Name, UpdateSourceTrigger=LostFocus}"/>
            </DataTrigger>
            <DataTrigger Binding="{Binding trigger}" Value="PropertyChanged">
                <Setter Property="Text" Value="{Binding Name, UpdateSourceTrigger=PropertyChanged}"/>
            </DataTrigger>
        </Style.Triggers>
    </Style>
