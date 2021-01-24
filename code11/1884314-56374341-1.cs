C#
   public class Document : BaseModel<int>, IDocument, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion // INotifyPropertyChanged
        public bool HasDefaultColor
        {
            get => hasDefaultColor;
            set
            {
                hasDefaultColor = value;
                OnPropertyChanged();
            }
        }
    }
The converter 
C#
public class BoolToColorConverter : IValueConverter (see question for detailed code...)
The implementation of the converter in xaml: 
C# 
<Frame BackgroundColor="{Binding HasDefaultColor, Converter={converters:BoolToColorConverter}}"  Padding="0" HorizontalOptions="FillAndExpand" HasShadow="True">
And finally (which was the part where I got stuck with), properly updating the collection in the binded viewmodel in the OnTapped() method:
C#
        private void DocumentViewCell_OnTapped(object sender, EventArgs e)
        {
            try
            {
                // Determine which document was selected
                if (sender.GetType() == typeof(ViewCell))
                {
                    ViewCell selectedViewCell = (ViewCell)sender;
                    if (selectedViewCell.BindingContext != null && selectedViewCell.BindingContext.GetType() == typeof(Document))
                    {
                        Document document = (Document)selectedViewCell.BindingContext;
                        
                        if (document != null)
                        {
                            // Update default color (viewcell) for binded model
                            document.HasDefaultColor = !document.HasDefaultColor;
                            // Update backing field selectedDocument for correct bindings and to show correct detail page
                            ObservableCollection<Grouping<string, Document>> documents = viewModel.GroupedDocuments;
                            foreach (var group in documents)
                            {
                                foreach (var doc in group)
                                {
                                    if (doc.Name == document.Name)
                                    {
                                        doc.HasDefaultColor = document.HasDefaultColor;
                                    }
                                }
                            }
                            viewModel.GroupedDocuments = documents;
                            selectedDocument = document;
                        }
                    }
               }
           }
       }
