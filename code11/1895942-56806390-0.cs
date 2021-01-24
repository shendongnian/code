        public PXAction<UploadFileWithIDSelector> AddtoLazada;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Add image to Lazada")]
        public virtual IEnumerable addtoLazada(PXAdapter adapter)
        {
            if (this.Base.Files.Current != null)
            {
                var externalval = this.Base.Files.Current.ExternalLink;
            }
            return adapter.Get();
        }
