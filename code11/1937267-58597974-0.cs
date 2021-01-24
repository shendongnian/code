    public class MyListItem : BindableObject {
        public string Image { get; set; }
        public MyListItem(string url) {
        ...
            setImage(url);
        }
    
        private async void setImage(string url) {
            Image = await MyCachingLib.GetUrlAsync(url);
            OnPropertyChanged(nameof(Image));
        }
    }
