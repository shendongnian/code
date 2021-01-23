    <ListView>
        <ListView.View>
            <GridView>
                <GridViewColumn Width="140" Header="Date" />
                <GridViewColumn Width="140" Header="Day" 
                                DisplayMemberBinding="{Binding DayOfWeek}" />
                <GridViewColumn Width="140" Header="Year" 
                                DisplayMemberBinding="{Binding Year}"/>
            </GridView>
        </ListView.View>
    
        <sys:DateTime>1/2/3</sys:DateTime>
        <sys:DateTime>4/5/6</sys:DateTime>
        <sys:DateTime>7/8/9</sys:DateTime>
    </ListView>
