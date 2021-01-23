        <Button Margin="0,0,5,0" Cursor="Hand"
                ToolTip="Search"  Command="{Binding SearchButton}"
                IsEnabled="{Binding ElementName=SaveButton,Path=IsEnabled,       
                UpdateSourceTrigger=PropertyChanged,Mode=TwoWay}">
           <i:Interaction.Triggers>
              <i:EventTrigger EventName="Click" >
                 <cmd:EventToCommand 
                      PassEventArgsToCommand="False"
                      Command="{Binding SearchButton}"
                 />
              </i:EventTrigger>
           </i:Interaction.Triggers>
           <Button.ContentTemplate>
             <DataTemplate>
               <Grid>
                  <AccessText Visibility="Collapsed">_Search</AccessText>
                  <Image Source="/CHKRevAcc;component/Images/search.png" />
               </Grid>
             </DataTemplate>
           </Button.ContentTemplate> 
        </Button>
