    <ListBox x:Name="EbookBox" ItemTemplate="{StaticResource ListItemTemplate}" Height="505" ItemsSource="{Binding OBooks, Mode=OneWay}" SelectedItem="{Binding SelectedBook, Mode=TwoWay}">
       <i:Interaction.Triggers>
          <i:EventTrigger EventName="SelectionChanged">
             <cmd:EventToCommand Command="{Binding LoadCoverCommand, Mode=OneWay}" />
          </i:EventTrigger>
       </i:Interaction.Triggers>
    </ListBox>
