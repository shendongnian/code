    // Value points to the current DataContext object's CanSaveObject property
    <Button IsEnabled="{Binding CanSaveObject}" />
    
    // Value points to the IsChecked property of CheckBoxA
    <Button IsEnabled="{Binding ElementName=CheckBoxA, Path=IsChecked}" />
    
    // Value points to the value False
    <Button IsEnabled="False" />
