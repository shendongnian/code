suppressEvents = true;
if (selectedLayers.TrueForAll(o => o.Name == selectedLayer.Name)) {
    SelectedNameBox.Text = selectedLayer.Name;
} else {
    SelectedNameBox.Text = "";
}
...
suppressEvents = false;
Then the ChangedEvents of the editing controls update all the SelectedItems.
private void SelectedNameBox_TextChanged(object sender, TextChangedEventArgs e) {
    if (suppressEvents) return;
    string t = (sender as TextBox).Text;
    foreach (HitsoundLayer hitsoundLayer in LayersList.SelectedItems) {
        hitsoundLayer.Name = t;
    }
}
