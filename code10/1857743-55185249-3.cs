    <ListView x:Name="LeavesListView" Margin="10,10,13,10" Background="White" Opacity="0.8" Grid.Row="2" FontFamily="Times New Roman" FontSize="14" FlowDirection="RightToLeft" SelectionChanged="LeavesListView_SelectionChanged" MouseDoubleClick="LeavesListView_MouseDoubleClick">
        <ListView.Resources>
            <local:DateConverter x:Key="DateConverter" />
        </ListView.Resources>
        <ListView.View>
            <GridView>
                <GridViewColumn Header="تاريخ البدء" Width="120" TextBlock.TextAlignment="Center" DisplayMemberBinding="{Binding StartDate, Converter={StaticResource DateConverter}}" FrameworkElement.FlowDirection="RightToLeft"/>
                <GridViewColumn Header="تاريخ الأنتهاء" Width="120" TextBlock.TextAlignment="Center" DisplayMemberBinding="{Binding EndDate, Converter={StaticResource DateConverter}}" FrameworkElement.FlowDirection="RightToLeft" />
                <GridViewColumn Header="نوع الاجازة" Width="100" FrameworkElement.FlowDirection="RightToLeft">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding LeaveType}"  Foreground="Red" />
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
