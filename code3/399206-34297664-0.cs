        public MyViewModel()
        {
            PlayPreviewCommand= new DelegateCommand(PlayPreview, CanPlayPreview);
        }
        public ICommand PlayPreviewCommand
        {
            get;
            set;
        }
        public void PlayPreview(object par)
        {
            if (par != null && par is MediaElement)
            {
                var preview = composition.GeneratePreviewMediaStreamSource(640, 480);
                (par as MediaElement).SetMediaStreamSource(preview);
                (par as MediaElement).Play();
            }
        }
