    public interface IMedia : IValidationDictionary, IBaseDescriptor {
        /// <summary>
        /// Returns a specific Media object specifying 
        /// if you want the full or lite version
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isLite"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IMedia Get(long id, bool isLite, DataContext context);
        /// <summary>
        /// Returns the lite version of the request Media object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IMedia Get(long id, DataContext context);
        /// <summary>
        /// Returns a list of Media Objects
        /// </summary>
        /// <param name="isLite"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        ValidationList<IMedia> List(bool isLite, DataContext context);
        /// <summary>
        /// Returns a list of Media Objects with pagination capabilities
        /// </summary>
        /// <param name="isLite"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        ValidationList<IMedia> List(bool isLite, int skip, int top, DataContext context);
    }
    public partial class Media : BaseDescriptor, IMedia {
        #region Constructors
        public Media(String key, IError error)
            : base() {
            AddError(key, error);
        }
        #endregion
        #region Properties
        public MediaType Type {
            set { if (TypeID <= 0) { MediaType = value; } }
            get { return MediaType; }
        }
        #endregion
        #region Internal Methods
        /// <summary>
        /// Truncates relationships as appropriate to reduce over-the-wire size 
        /// </summary>
        protected override void MakeLite() {
            MediaRelateds = new EntitySet<MediaRelated>();
        }
        /// <summary>
        /// Validates the values and returns true if there are no problems.
        /// </summary>
        override public bool Validate() {
            this.ClearErrors();
            if (this.TypeID <= 0) { this.AddError("TypeID", new Error(ErrorType.VALIDATION, "TypeID is missing or invalid")); }
            if (string.IsNullOrEmpty(this.Path)) { this.AddError("Path", new Error(ErrorType.VALIDATION, "Path is missing or invalid")); }
            if (this.CreatedOn.Year <= 1900) { this.AddError("CreatedOn", new Error(ErrorType.VALIDATION, "CreatedOn is missing or invalid")); }
            if (this.CreatedBy <= 0) { this.AddError("CreatedBy", new Error(ErrorType.VALIDATION, "CreatedBy is missing or invalid")); }
            if (this.UpdatedOn.Year <= 1900) { this.AddError("UpdatedOn", new Error(ErrorType.VALIDATION, "UpdatedOn is missing or invalid")); }
            if (this.UpdatedBy <= 0) { this.AddError("UpdatedBy", new Error(ErrorType.VALIDATION, "UpdatedBy is missing or invalid")); }
            if (!string.IsNullOrEmpty(this.Path) && this.Path.Length > 255) { this.AddError("Path", new Error(ErrorType.VALIDATION, "Path is longer than the maximum of 255 characters")); }
            return (this.ErrorCount == 0);
        }
        #endregion
        #region Public Methods
        public ValidationList<IMedia> List(bool isLite, DataContext context) {
            return List(isLite, 0, 0, context);
        }
        public ValidationList<IMedia> List(bool isLite, int skip, int top, DataContext context) {
            if (context == null) { context = new DataContext(); }
            var query = context.Medias.Where(x => x.DeletedOn == null);
            List<Media> results;
            if (skip > 0 || top > 0) {
                if (top > 0) {
                    if (skip < 0) { skip = 0; }
                    results = query.OrderBy(x => x.ID).Skip(skip).Take(top).ToList();
                } else {
                    results = query.OrderBy(x => x.ID).Skip(skip).ToList();
                }
            } else {
                results = query.OrderBy(x => x.ID).ToList();
            }
            var finalResult = new ValidationList<IMedia>(new List<IMedia>());
            foreach (var result in results) {
                result.IsLite = isLite;
                finalResult.Source.Add(result);
            }
            return finalResult;
        }
        public IMedia Get(long id, DataContext context) {
            return Get(id, false, context);
        }
        public IMedia Get(long id, bool isLite, DataContext context) {
            if (context == null) { context = new DataContext(); }
            var results = context.Medias.Where(x => x.ID == id && x.DeletedOn == null).ToList();
            var result = (results.Count > 0 ? results[0] : null);
            if (result != null) {
                result.IsLite = isLite;
            }
            return result;
        }
        #endregion
    }
}
