    private  void TargetListView_DragOver(object sender, DragEventArgs e)
    {
        // Our list only accepts text
        e.AcceptedOperation = (e.DataView.Contains(StandardDataFormats.Text)) ? DataPackageOperation.Copy : DataPackageOperation.None;
        VisualStateManager.GoToState(this, "Inside", true);
    }
    
    
    private async void TargetListView_Drop(object sender, DragEventArgs e)
    {
      
        if (e.DataView.Contains(StandardDataFormats.Text))
        {
          
            var def = e.GetDeferral();
            var s = await e.DataView.GetTextAsync();
            var items = s.Split('\n');
            foreach (var item in items)
            {
                _selection.Add(item);
            }
            e.AcceptedOperation = DataPackageOperation.Copy;
            VisualStateManager.GoToState(this, "Outside", true);
            def.Complete();
        }
    }
