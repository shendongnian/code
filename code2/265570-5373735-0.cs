    <Window.Resources>
        <Style TargetType="{x:Type TabItem}" x:Key="TabItemStyle1">
          <Setter Property="Template">
            <Setter.Value>
              <ControlTemplate TargetType="{x:Type TabItem}">
                <Grid>
                 ------------
                 ------------
                </Grid>
              </ControlTemplate>
            </Setter.Value>
          </Setter>
        </Style>
        <Style TargetType="{x:Type TabItem}" x:Key="TabItemStyle2">
          <Setter Property="Template">
            <Setter.Value>
              <ControlTemplate TargetType="{x:Type TabItem}">
                <Grid>
                 ------------
                 ------------
                </Grid>
              </ControlTemplate>
            </Setter.Value>
          </Setter>
        </Style>
      </Window.Resources>
    <Grid>
          <TabControl Height="181" VerticalAlignment="Top">
            <TabItem Header="Cheese" Style="{StaticResource TabItemStyle1} />
            <TabItem Header="Pepperoni" Style="{StaticResource TabItemStyle1} />
            <TabItem Header="Mushrooms" Style="{StaticResource TabItemStyle1} />
          </TabControl>
          <TabControl Margin="0,201,0,60">
            <TabItem Header="Cheese" Style="{StaticResource TabItemStyle2} />
            <TabItem Header="Pepperoni" Style="{StaticResource TabItemStyle2} />
            <TabItem Header="Mushrooms" Style="{StaticResource TabItemStyle2} />
          </TabControl>
      </Grid>
