    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using Xamarin.Forms;
    
    namespace SearchContent
    {
        public partial class ListView : ContentPage
        {
    
            ObservableCollection<Content> contents { get; set; }
            public ListView()
            {
                InitializeComponent();
            }
    
            protected override void OnAppearing()
            {
    
                base.OnAppearing();
    
                contents = new ObservableCollection<Content>()
                {
                    new Content("Chapter 1", "Description of Chapter 1", new Page1()),
                    new Content("Chapter 2", "Description of Chapter 2", new Page2()),
                };
    
                listView.ItemsSource = contents;
    
            }
    
    
            private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
            {
                Navigation.PushAsync(((Content)e.Item).ChapterPage);
            }
    
            private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
            {
                String textToSearch = ((SearchBar)sender).Text;
    
                var contentsFiltered = contents.Where(item => ((Interface1)item.ChapterPage).PageText.Contains(textToSearch));
    
                ObservableCollection<Content> newContents = new ObservableCollection<Content>(contentsFiltered);
    
                listView.ItemsSource = null;
                listView.ItemsSource = newContents;
    
            }
    
            private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
            {
                if(String.IsNullOrEmpty(e.NewTextValue))
                {
                    listView.ItemsSource = null;
                    listView.ItemsSource = contents;
                }
            }
        }
    
    
        public class Content
        {
            public String Chapter { get; set; }
    
            public String Description { get; set; }
    
            public Page ChapterPage { get; set; }
    
            public Content(String chapter, String description, Page chapterPage)
            {
    
                Chapter = chapter; 
                Description = description;
                ChapterPage = chapterPage;
    
            }
    
        }
    
    }
