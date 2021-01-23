    public class ContentBuilderContainer : IContentBuilderContainer
    {
        // Other members removed for simplicity.
        #region Static Properties
        /// <summary>
        /// Gets or sets the current content builder container.
        /// </summary>
        public static IContentBuilderContainer Current
        {
            get;
            set;
        }
        #endregion
        #region Static Constructors
        static ContentBuilderContainer()
        {
            ContentBuilderContainer.Current = new ContentBuilderContainer();
        }
        #endregion
    }
