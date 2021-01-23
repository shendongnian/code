    public ObservableCollection<StyleModelBase> Styles { get; }
    public StyleModelBase SelectedStyle {
      get { return selectedStyle; }
      set {
        if (value is CustomStyleModel) {
          var buffer = SelectedStyle;
          var items = Styles.ToList();
          if (openFileDialog.ShowDialog() == true) {
            value.FileName = openFileDialog.FileName;
          }
          else {
            Styles.Clear();
            items.ForEach(x => Styles.Add(x));
            SelectedStyle = buffer;
            return;
          }
        }
        selectedStyle = value;
        OnPropertyChanged(() => SelectedStyle);
      }
    }
