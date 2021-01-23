    <DataTrigger Binding="{Binding Path=IsValid}" Value="True">
      <DataTrigger.EnterActions>
           <BeginStoryboard Name="sb">
                  <Storyboard>
                     ...                                
                  </Storyboard>
           </BeginStoryboard>
      </DataTrigger.EnterActions>
      <DataTrigger.ExitActions>
           <StopStoryboard BeginStoryboardName="sb" />
      </DataTrigger.ExitActions>
    </DataTrigger>
