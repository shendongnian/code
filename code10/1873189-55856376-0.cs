    public void DeletePlaylist()
        {
            Playlists.Remove(newPlaylist);
        }
        public void EditPlaylist()
        {
            newPlaylist.Title="Refreshed Playlist"
        }
    
    public class Playlist:INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
           get{return title;}
           set{title=value;
               NotifyPropertyChanged();}  
        }
    }
