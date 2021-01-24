cs
private void Window_Loaded(object sender, RoutedEventArgs e) {
	//Subscribe to generated containers event of the ItemsControl
	MyItemsControl.ItemContainerGenerator.StatusChanged += ContainerGenerator_StatusChanged;
}
/// <summary>
/// Handles changed in container generator status.
///</summary>
private void ContainerGenerator_StatusChanged(object sender, EventArgs e) {
	var generator = sender as ItemContainerGenerator;
	//Check that containers have been generated
	if (generator.Status == GeneratorStatus.ContainersGenerated ) {
		//Do stuff
	}
}
I really recommand not to use this if what you're after is simply save/load data from a file, as they are completely unrelated.
