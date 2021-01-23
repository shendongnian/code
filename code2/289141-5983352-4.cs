    <ListView ItemsSource="{Binding AveragingParameters}">
      <ListView.View>
        <GridView AllowsColumnReorder="False">
    
          <GridViewColumn Header="Parameter">
            <GridViewColumn.CellTemplate>
              <DataTemplate>
                <DockPanel>
                  <TextBlock Text="{Binding Name}" />
                </DockPanel>
              </DataTemplate>
            </GridViewColumn.CellTemplate>
          </GridViewColumn>
    
          <GridViewColumn>
            <GridViewColumn.CellTemplate>
              <DataTemplate>
                <Grid HorizontalAlignment="Stretch">
                  <CheckBox  x:Name="chkAvg" IsChecked="{Binding CalcAverage}" />
                </Grid>
              </DataTemplate>
            </GridViewColumn.CellTemplate>
    
            <CheckBox x:Name="chkAvgSelectAll" Content="Avg" 
                      Tag="CalcAvg" Command="SelectAllCheckedCommand" 
                      ToolTip="Select All">
                <MultiBinding Converter="{StaticResource SelectAllConverter}">
                  <Binding Path="Tag" RelativeSource="{RelativeSource self}" />
                  <Binding Path="IsChecked" RelativeSource="{RelativeSource self}" />
                </MultiBinding>
            </CheckBox>
          </GridViewColumn>
    
          <GridViewColumn>
            <GridViewColumn.CellTemplate>
              <DataTemplate>
                <Grid HorizontalAlignment="Stretch">
                  <CheckBox  x:Name="chkMin" IsChecked="{Binding CalMin}" />
                </Grid>
              </DataTemplate>
            </GridViewColumn.CellTemplate>
    
            <CheckBox x:Name="chkMinSelectAll" Content="Avg" 
                      Tag="CalcMin" Command="SelectAllCheckedCommand" 
                      ToolTip="Select All">
                <MultiBinding Converter="{StaticResource SelectAllConverter}">
                  <Binding Path="Tag" RelativeSource="{RelativeSource self}" />
                  <Binding Path="IsChecked" RelativeSource="{RelativeSource self}" />
                </MultiBinding>
            </CheckBox>
          </GridViewColumn>
    
        </GridView>
      </ListView.View>
    </ListView>
