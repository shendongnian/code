    public sealed partial class MainPage : Page
    {
    
        private dynamic jsonObj;
        public string editpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Notas.json");
        public ObservableCollection<Notes> Mynotes;
        public MainPage()
        {
            this.InitializeComponent();
            
            string json = File.ReadAllText(editpath);
            jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
    
        }
    
        private void Titulo_TextChanged(object sender, TextChangedEventArgs e)
        {
            #region
    
            int indice = listNotas.SelectedIndex;
            jsonObj["notes"][indice]["title"] = titulo.Text;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj);
            editor.TextDocument.SetText(Windows.UI.Text.TextSetOptions.None, output);
            File.WriteAllText(editpath, output);
            #endregion
    
        }
    }
