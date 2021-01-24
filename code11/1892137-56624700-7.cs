    <Window.Resources>
      <Style x:Key="OpacityStyle" TargetType="TextBox">
        <Setter Property="Opacity" Value="0" />
        <Setter Property="IsEnabled" 
                Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType=Window}, Path=IsEditEnabled}" />
    
        <Style.Triggers>
          <DataTrigger Binding="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType=Window}, Path=IsEditEnabled}"
                       Value="True">
                  
            <! Fade in animation -->
            <DataTrigger.EnterActions>
              <BeginStoryboard>
                <Storyboard>
                  <DoubleAnimation Storyboard.TargetProperty="Opacity"
                                       BeginTime="0:0:0"
                                       From="0"
                                       To="1"
                                       Duration="0:0:0.2" />
                </Storyboard>
              </BeginStoryboard>
            </DataTrigger.EnterActions>
    
            <! Fade out animation -->
            <DataTrigger.ExitActions>
              <BeginStoryboard>
                <Storyboard>
                  <DoubleAnimation Storyboard.TargetProperty="Opacity"
                                       BeginTime="0:0:0"
                                       From="1"
                                       To="0"
                                       Duration="0:0:0.2" />
                </Storyboard>
              </BeginStoryboard>
            </DataTrigger.ExitActions>        
          </DataTrigger>
        </Style.Triggers>
      </Style>
    </Window.Resources>
    
    <Grid>
      <StackPanel>
        <ToggleButton x:Name="EditButton" IsChecked="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType=Window}, Path=IsEditEnabled, Mode=TwoWay}" />
        <TextBox x:Name="AnimatedTextBox" Style="{StaticResource TextBoxAnimationStyle}" >
        <TextBox x:Name="AnotherAnimatedTextBox" Style="{StaticResource TextBoxAnimationStyle}" >
        <TextBox x:Name="NonanimatedTextBox" >
      </StackPanel>
    </Grid>
