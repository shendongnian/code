    <ContextMenu Name="conKostenstelle" >
     <MenuItem Header="Kostenstellen" Name="menuItemKostenstellen">
        <MenuItem.ItemContainerStyle>
            <Style TargetType="{x:Type MenuItem}">
                <EventSetter Event="Click" Handler="MenuItem_Click" />
            </Style>
        </MenuItem.ItemContainerStyle>
    
     </MenuItem>
    </ContextMenu>
    
     LinkedList<String> kliste = kosrep.GetKostenstellen();
    
    menuItemKostenstellenunter.ItemsSource = kliste;
