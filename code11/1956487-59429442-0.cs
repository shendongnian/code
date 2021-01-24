    private async void CreateUsers(object sender, RoutedEventArgs e)
    {
      Task.Factory.StartNew(()=>{
        using (var context = new AsyncDbContext())
        {
            await context.Users.AddRangeAsync(new List<User>
                {
                     new User{Name="1"},
                     new User{Name="2"},
                     new User{Name="3"},
                     new User{Name="4"},
                     new User{Name="5"},
                     new User{Name="6"},
                     new User{Name="7"},
                     new User{Name="8"},
                });
            await context.SaveChangesAsync();
            MessageBox.Show("Done!");
    });
    }
     
