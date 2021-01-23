    [DataContract(Name = "ServiceResponseOf{0}")]
    public class ServiceResponse<TDto> : ResponseTransferObjectBase<TDto> where TDto : IDto
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse&lt;TDto&gt;"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <remarks></remarks>
        public ServiceResponse(ServiceErrorBase error)
            : this(ResponseStatus.Failure, null, new List<ServiceErrorBase> {error}, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse&lt;TDto&gt;"/> class.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <remarks></remarks>
        public ServiceResponse(IEnumerable<ServiceErrorBase> errors)
            : this(ResponseStatus.Failure, null, errors, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse&lt;TDto&gt;"/> class with a status of <see cref="ResponseStatus.Failure"/>.
        /// </summary>
        /// <param name="validationResults">The validation results.</param>
        public ServiceResponse(MSValidation.ValidationResults validationResults)
            : this(ResponseStatus.Failure, null, null, validationResults)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse&lt;TDto&gt;"/> class with a status of <see cref="ResponseStatus.Success"/>.
        /// </summary>
        /// <param name="data">The response data.</param>
        public ServiceResponse(TDto data)
            : this(ResponseStatus.Success, new List<TDto> { data }, null, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse&lt;TDto&gt;"/> class with a status of <see cref="ResponseStatus.Success"/>.
        /// </summary>
        /// <param name="data">The response data.</param>
        public ServiceResponse(IEnumerable<TDto> data)
            : this(ResponseStatus.Success, data, null, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse&lt;TDto&gt;"/> class.
        /// </summary>
        /// <param name="responseStatus">The response status.</param>
        /// <param name="data">The data.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="validationResults">The validation results.</param>
        /// <remarks></remarks>
        private ServiceResponse(ResponseStatus responseStatus, IEnumerable<TDto> data, IEnumerable<ServiceErrorBase> errors, MSValidation.ValidationResults validationResults)
        {
            Status = responseStatus;
            Data = (data != null) ? new List<TDto>(data) : new List<TDto>();
            Errors = Mapper.Map<IEnumerable<ServiceErrorBase>, List<ServiceError>>(errors) ??
                     new List<ServiceError>();
            ValidationResults = 
                Mapper.Map<MSValidation.ValidationResults, List<IValidationResult>>(validationResults) ??
                new List<IValidationResult>();
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the <see cref="IDto"/> data.
        /// </summary>
        [DataMember(Order = 0)]
        public List<TDto> Data { get; private set; }
        [DataMember(Order = 1)]
        public List<ServiceError> Errors { get; private set; }
        /// <summary>
        /// Gets the <see cref="ValidationResults"/> validation results.
        /// </summary>
        [DataMember(Order = 2)]
        public List<IValidationResult> ValidationResults { get; private set; }
        /// <summary>
        /// Gets the <see cref="ResponseStatus"/> indicating whether the request failed or succeeded.
        /// </summary>
        [DataMember(Order = 3)]
        public ResponseStatus Status { get; private set; }
        #endregion
    }
