    <DataTemplate>
      <StackPanel>     
        <TextBlock Text="{Binding Title}"/> 
        <Button Click="MyBtn_Click" CommandParameter={Binding Title}/>   
        </StackPanel> 
    </DataTemplate> 
    public void MyBtn_Click(object sender, args)
    {
        string MyVal = (sender as Button).CommandParameter.ToString();
    }
