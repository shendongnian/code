        public partial class ParentView : ContentPage
        {
                public ParentView()
                {            
                    InitializeComponent();
                }
                private void LanguagePicker_SelectedIndexChanged(object sender, System.EventArgs e)
                {
                    var parentViewModel = (ParentViewModel)this.BindingContext;
                    parentViewModel.SelectedLanguageChanged(sender,e);
                }
        }
