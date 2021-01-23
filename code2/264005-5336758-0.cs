    void wc_DownloadStringCompleted(object sender,
                                    DownloadStringCompletedEventArgs e)
    {
        XDocument dataDoc = XDocument.Load(new StringReader(e.Result));
        var listitems = from noticia in dataDoc.Descendants("Noticia")
                        select new News()
                        {
                            id = (string) noticia.Element("IdNoticia"),
                            published = (string) noticia.Element("Data"),
                            title = (string) noticia.Element("Titol"),
                            subtitle = (string) noticia.Element("Subtitol"),
                            thumbnail = (string) noticia.Element("Thumbnail")
                        };
        itemList.ItemsSource = listitems;
    }
