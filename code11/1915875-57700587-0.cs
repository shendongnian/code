xaml
<DataGrid x:Name="DecksummeAnzeige" AutoGenerateColumns="False" Margin="0" FrozenColumnCount="4" AlternatingRowBackground="Gainsboro"  AlternationCount="2">
    <DataGrid.Columns>
        <DataGridTextColumn Binding="{Binding Path=ParticipantId}" Header="ID" IsReadOnly="True" />
        <DataGridTextColumn Binding="{Binding Path=Forename}" Header="Vorname" IsReadOnly="True" />
        <DataGridTextColumn Binding="{Binding Path=Name}" Header="Name" IsReadOnly="True" />
        <DataGridTemplateColumn Header="Ergebnisse" IsReadOnly="True">
           <DataGridTemplateColumn.CellTemplate>
               <DataTemplate>
                    <!--here is the changes-->
                    <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Disciplines}" HeadersVisibility="None">
                        <DataGrid.Columns>
                            <DataGridTextColumn Binding="{Binding Path=DisciplineId}" IsReadOnly="True" />
                            <DataGridTextColumn Binding="{Binding Path=Name }" IsReadOnly="True"/>
                        </DataGrid.Columns>
                    </DataGrid>
                    <!--end here-->
                </DataTemplate>
             </DataGridTemplateColumn.CellTemplate>
          </DataGridTemplateColumn>
       </DataGrid.Columns>
   </DataGrid>
