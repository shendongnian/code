    <ListView Name="Employees_Listview" 
              ItemsSource="{Binding DisplayEmployees, UpdateSourceTrigger=PropertyChanged}" 
              SelectedItem="{Binding YourSelectedItem, Mode=TwoWay}" Height="109">
        <ListView.View>
            <GridView>
                <GridViewColumn Header="FirstName" DisplayMemberBinding="{Binding FirstName}"/>
                <GridViewColumn Header="LastName" DisplayMemberBinding="{Binding LastName}"/>
                <GridViewColumn Header="Departments" DisplayMemberBinding="{Binding Dept.Dept}"/>
            </GridView>
        </ListView.View>
    </ListView>
