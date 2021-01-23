    <!-- prevent the tab from being changed while editing or adding a physician -->
    <Style BasedOn="{StaticResource {x:Type TabControl}}" 
            TargetType="{x:Type TabControl}" x:Key="InactivateTabControl">
        <!-- <Setter Property="IsEnabled" Value="True" /> -->
        <Style.Triggers>
            <DataTrigger Binding="{Binding PhysicianTypeTabAreLocked}" Value="False">
                <Setter Property="IsEnabled" Value="True" />
            </DataTrigger>
            <DataTrigger Binding="{Binding PhysicianTypeTabAreLocked}" Value="True">
                <Setter Property="IsEnabled" Value="False" />
            </DataTrigger>
        </Style.Triggers>
    </Style>
    <TabControl Grid.Row="1" Grid.Column="0" Margin="0, 10, 0, 0"
         x:Name="PhysicianTypesTabControl" 
         SelectedIndex="{Binding PhysicianTypeSelectedTabIndex, Mode=TwoWay}" 
         Style="{StaticResource InactivateTabControl}">
    
        <!-- rest here ....-->
     <TabControl/>
