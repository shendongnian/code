      foreach (var item in DgvProjectTaskList.Items)
      {
        bool enable = item.Task.State != TaskStates.Done;
        var contentPresenter = Data.Columns[4].GetCellContent(item );
        var picker = VisualTreeHelper.GetChild(contentPresenter, 0) as DatePicker;
        picker.IsEnabled = enable;
        contentPresenter = Data.Columns[5].GetCellContent(item );
        picker = VisualTreeHelper.GetChild(contentPresenter, 0) as DatePicker;
        picker.IsEnabled = enable;
      }
