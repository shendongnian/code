    List<string> listItems;
    if (listBoxXmlFilesReference.SelectedIndices.Count < 2) {
        listItems = listBoxXmlFilesReference.Items.Cast<string>().ToList();
    } else {
        listItems = listBoxXmlFilesReference.SelectedItems.Cast<string>().ToList();
    }
    foreach (string filename in listItems) {
        // ..
    }
