    SqlConnection con = new SqlConnection();
    SqlDataAdapter ad = new SqlDataAdapter();
    SqlCommand cmd = new SqlCommand();
    String str = "SELECT EmployeeID, FirstName, LastName, BirthDate, City, Country FROM Employees";
    cmd.CommandText = str;
    ad.SelectCommand = cmd;
    con.ConnectionString = "Data Source=MyData.sdf;Persist Security Info=False";
    cmd.Connection = con;
    DataSet ds = new DataSet();
    ad.Fill(ds);
    ListViewEmployeeDetails.DataContext = ds.Tables[0].DefaultView;
    con.Close();
    ....
    <Grid x:Name="Grid1">
      <ListView Name="ListViewEmployeeDetails" Margin="4,20,40,100" ItemTemplate="{DynamicResource EmployeeTemplate}" ItemsSource="{Binding Path=Table}">
        <ListView.View>         
          <GridView>
            <GridViewColumn Header="Employee ID" DisplayMemberBinding="{Binding Path=EmployeeID}"/>
            <GridViewColumn Header="First Name" DisplayMemberBinding="{Binding Path=FirstName}"/>
            <GridViewColumn Header="Last Name" DisplayMemberBinding="{Binding Path=LastName}"/>
            <GridViewColumn Header="BirthDate" DisplayMemberBinding="{Binding Path=BirthDate}"/>
            <GridViewColumn Header="City" DisplayMemberBinding="{Binding Path=City}"/>
            <GridViewColumn Header="Country" DisplayMemberBinding="{Binding Path=Country}"/>
          </GridView>
        </ListView.View>
      </ListView>
    </Grid>
