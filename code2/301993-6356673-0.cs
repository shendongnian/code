    <Page xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
      <Grid>
        <TabControl BorderThickness="0" Padding="0">
          <TabControl.Resources>
            <Style TargetType="TabItem">
              <Setter Property="Template">
                <Setter.Value>
                  <ControlTemplate TargetType="TabItem">
                  </ControlTemplate>
                </Setter.Value>
              </Setter>
            </Style>
          </TabControl.Resources>
          <TabItem Header="Not shown">
            <Grid Background="Red"/>
          </TabItem>
          <TabItem>
            <TextBlock HorizontalAlignment="Center" VerticalAlignment="Center">Tab 2
            
            </TextBlock>
          </TabItem>
        </TabControl>
      </Grid>
    </P
