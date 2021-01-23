    <ListView.View>
        <GridView>
            <GridViewColumn Header="ID" Width="20" 
                            DisplayMemberBinding="{Binding Path=NoteReminderID}" />
            <GridViewColumn Header="Entered Date" Width="Auto" 
                            DisplayMemberBinding="{Binding Path=NoteReminderEnterDate}" />
            <GridViewColumn Header="Due Date" Width="75" 
                            DisplayMemberBinding="{Binding Path=NoteReminderDueDate}" />
            <GridViewColumn Header="Note Contents" Width="300" 
                            DisplayMemberBinding="{Binding Path=NoteReminderConents}" />
            <GridViewColumn Header="Completed" Width="Auto">
                <GridViewColumn.CellTemplate>
                    <DataTemplate>
                        <CheckBox IsChecked="{Binding Path=NoteReminderCompleted}"/>
                    </DataTemplate>
                </GridViewColumn.CellTemplate>
            </GridViewColumn>
        </GridView>
    </ListView.View>
    
