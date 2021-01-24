    private void LbSelectedSubject_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        int index = lbSelectedSubject.IndexFromPoint(e.Location);
        if (index != ListBox.NoMatches)
        {
            // Always do this before removing the element from the BindingSource
            selectedValueSubject.Remove((int)lbSelectedSubject.SelectedValue);
            bsSelected.Remove(lbSelectedSubject.SelectedItem);
            // lbSelectedSubject.Items.RemoveAt(index);
        }
    }
