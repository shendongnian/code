    <StackPanel>
       <ContentControl>
          <ContentControl.Style>
             <Style TargetType="ContentControl">
                <Setter Property="Visibility" Value="Collapsed"/>
                <Style.Triggers>
                   <DataTrigger Binding="{Binding Name}" Value="Thing1">
                      <Setter Property="Visibility" Value="Visible"/>
                   </DataTrigger>
                </Style.Triggers>
             </Style>
          </ContentControl.Style>
          <!-- content to display when Name = Thing1 goes here -->
       </ContentControl>
       <ContentControl>
          <ContentControl.Style>
             <Style TargetType="ContentControl">
                <Setter Property="Visibility" Value="Collapsed"/>
                <Style.Triggers>
                   <DataTrigger Binding="{Binding Name}" Value="Thing2">
                      <Setter Property="Visibility" Value="Visible"/>
                   </DataTrigger>
                </Style.Triggers>
             </Style>
          </ContentControl.Style>
          <!-- content to display when Name = Thing2 goes here -->
       </ContentControl>
    </StackPanel>
