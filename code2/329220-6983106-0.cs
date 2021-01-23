    <UserContorl.Resources>
        <ContextMenu x:Key="Condition1ContextMenu" ../>
        <ContextMenu x:Key="Condition2ContextMenu" ../>
    </UserControl.Resources>
    ...
    <Style TargetType="{x:Type dg:UCGrid}">
       <Style.Triggers>
          <DataTrigger Binding="{Binding Condition1}" Value="Value1">
              <Setter Property="ContextMenu" Value="{StaticResource Condition1ContextMenu}"/>
          </DataTrigger>
          <DataTrigger Binding="{Binding Condition2}" Value="Value2">
              <Setter Property="ContextMenu" Value="{StaticResource Condition2ContextMenu}"/>
          </DataTrigger>
       </Style.Triggers>
    </Style>
