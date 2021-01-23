        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            SetPlayerSource();
            base.OnNavigatedTo(e);
        }
        private void SetPlayerSource()
        {
            XDocument audioPlayer = XDocument.Load("Audio.xml");
            var aani = (from audio in audioPlayer.Descendants("Note")
                        where audio.Attribute("id").Value == name
                        select new AudioClass
                        {
                            Audio = (string)audio.Element("url").Value
                        }).SingleOrDefault();
            player.Source = new Uri(aani.Audio, UriKind.Relative);
        }
        private void ButtonKey_Click(object sender, RoutedEventArgs e)
        {
            var buttonName = (sender as Button).Name;
            var underscorePos = buttonName.IndexOf('_');
            name = buttonName.Substring(0, underscorePos);
            SetPlayerSource();
            player.Play();
        }
