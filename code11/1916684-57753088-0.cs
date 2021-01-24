    public class ViewModel : INotifyPropertyChanged
    {
        public string editpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Notas.json");
        public ObservableCollection<Notes> Mynotes { get; set; }
        public ViewModel()
        {
            LoadUpdate();
            SetSelectIndex(0);
        }
    
        private void SetSelectIndex(int index)
        {
            SelectItem = Mynotes[index];
        }
        private void LoadUpdate()
        {
            using (StreamReader file = File.OpenText(editpath))
            {
                var json = file.ReadToEnd();
                baseNotes mainnotes = JsonConvert.DeserializeObject<baseNotes>(json);
                Mynotes = new ObservableCollection<Notes>();
    
                foreach (var item in mainnotes.notes)
                {
                    Mynotes.Add(new Notes { title = item.title });
                }
    
            }
        }
    
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private Notes _selectItem;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public Notes SelectItem
        {
            get
            {
                return _selectItem;
            }
            set
            {
                _selectItem = value;
                OnPropertyChanged();
            }
        }
    }
