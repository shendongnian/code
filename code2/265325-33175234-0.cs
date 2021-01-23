    public enum CustomDateRangeType
    {
    /// <summary>
    /// The direct value of property.
    /// </summary>
    Value,
    /// <summary>
    /// The dependent property.
    /// </summary>
    DependentProperty
    }
    /// <summary>
    /// The CustomDateComparAttribute Validator
    /// </summary>
    [AttributeUsage(AttributeTargets.All | AttributeTargets.Property,        AllowMultiple = false, Inherited = true)]
     public sealed class CustomDateRangeAttribute : ValidationAttribute,  IClientValidatable
     {
    private const string UniversalDatePattern = "yyyy-M-d";
    /// <summary>
    /// The min date.
    /// </summary>
    private string minDate;
    /// <summary>
    /// The max date.
    /// </summary>
    private string maxDate;
    /// <summary>
    /// The date range type
    /// </summary>
    private CustomDateRangeType dateRangeType;
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomDateRangeAttribute"/> class.
    /// </summary>
    /// <param name="minDate">
    /// The min date in <example>yyyy-M-d</example> format. Throws FormatException exception if not provided in specified format.
    /// </param>
    /// <param name="maxDate">
    /// max date in <example>yyyy-M-d</example> format. Throws FormatException exception if not provided in specified format.
    /// </param>
    public CustomDateRangeAttribute(string minDate, string maxDate)
        : this(CustomDateRangeType.Value, minDate, maxDate)
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomDateRangeAttribute" /> class.
    /// </summary>
    /// <param name="dateRangeType">Type of the date range.</param>
    /// <param name="minDate">The minimum date dependent property or value. If value then it should be <example>yyyy-M-d</example> format.</param>
    /// <param name="maxDate">The maximum date property or value. If value then it should be <example>yyyy-M-d</example> format.</param>
    public CustomDateRangeAttribute(CustomDateRangeType dateRangeType, string minDate, string maxDate)
    {
        if (dateRangeType == CustomDateRangeType.Value)
        {
            if (!IsValidDate(minDate))
            {
                throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Max date should be in {0} format.", UniversalDatePattern));
            }
            if (!IsValidDate(maxDate))
            {
                throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Min date should be in {0} format.", UniversalDatePattern));
            }
        }
        this.dateRangeType = dateRangeType;
        this.minDate = minDate;
        this.maxDate = maxDate;
    }
    /// <summary>
    /// Gets the min date.
    /// </summary>
    public string MinDate
    {
        get
        {
            return this.minDate;
        }
    }
    /// <summary>
    /// Gets the max date.
    /// </summary>
    public string MaxDate
    {
        get
        {
            return this.maxDate;
        }
    }
    /// <summary>
    /// Gets the type of the date range.
    /// </summary>
    /// <value>
    /// The type of the date range.
    /// </value>
    public CustomDateRangeType DateRangeType
    {
        get
        {
            return this.dateRangeType;
        }
    }
    /// <summary>
    /// gets client validation rules
    /// </summary>
    /// <param name="metadata">
    /// meta data parameter
    /// </param>
    /// <param name="context">
    /// controller context
    /// </param>
    /// <returns>
    /// client validation rule
    /// </returns>
    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
        ModelMetadata metadata,
        ControllerContext context)
    {
        if (metadata != null)
        {
            return new[]
                       {
                           new ModelClientValidationCustomDateRangeRule(
                               this.ErrorMessageString,
                               this.DateRangeType,
                               this.MinDate,
                               metadata.PropertyName,
                               this.MaxDate)
                       };
        }
        return null;
    }
    /// <summary>
    /// overridden method
    /// </summary>
    /// <param name="value">
    /// value to be compared
    /// </param>
    /// <param name="validationContext">
    /// validation context
    /// </param>
    /// <returns>
    /// validation result
    /// </returns>
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var result = ValidationResult.Success;
        var errorResult = new ValidationResult(this.ErrorMessageString);
        if (value == null)
        {
            return result;
        }
        DateTime dateValue = (DateTime)value;
        if (this.DateRangeType == CustomDateRangeType.Value)
        {
            if (ParseDate(this.MinDate) <= dateValue && dateValue <= ParseDate(this.MaxDate))
            {
                return result;
            }
        }
        else
        {
            if (validationContext == null || string.IsNullOrEmpty(this.MinDate) || string.IsNullOrEmpty(this.MaxDate))
            {
                return errorResult;
            }
            var minDatePropertyInfo = validationContext.ObjectType.GetProperty(this.MinDate);
            var maxDatePropertyInfo = validationContext.ObjectType.GetProperty(this.MaxDate);
            if (minDatePropertyInfo == null || maxDatePropertyInfo == null)
            {
                return errorResult;
            }
            var minDateValue = Convert.ToDateTime(
                minDatePropertyInfo.GetValue(validationContext.ObjectInstance, null), 
                CultureInfo.CurrentCulture);
            var maxDateValue = Convert.ToDateTime(maxDatePropertyInfo.GetValue(validationContext.ObjectInstance, null), 
                CultureInfo.CurrentCulture);
            if (minDateValue <= dateValue && dateValue <= maxDateValue)
            {
                return result;
            }
        }
        return errorResult;
    }
    /// <summary>
    /// The parse date.
    /// </summary>
    /// <param name="dateValue">
    /// The date value.
    /// </param>
    /// <returns>
    /// The <see cref="DateTime"/>.
    /// </returns>
    private static DateTime ParseDate(string dateValue)
    {
        return DateTime.ParseExact(
            dateValue, UniversalDatePattern, 
            CultureInfo.InvariantCulture);
    }
    /// <summary>
    /// The is valid date.
    /// </summary>
    /// <param name="dateValue">
    /// The date value.
    /// </param>
    /// <returns>
    /// A value indicating whether the provided dateValue is a valid date.
    /// </returns>
    private static bool IsValidDate(string dateValue)
    {
        DateTime? date = null;
        var regex = new Regex(@"\d{4}-\d{1,2}-\d{1,2}");
        if (regex.IsMatch(dateValue))
        {
            var dateParts = dateValue.Split('-');
            if (dateParts.Length == 3)
            {
                date = new DateTime(
                    Convert.ToInt32(dateParts[0], CultureInfo.InvariantCulture),
                    Convert.ToInt32(dateParts[1], CultureInfo.InvariantCulture),
                    Convert.ToInt32(dateParts[2], CultureInfo.InvariantCulture));
            }
        }
        return date != null;
    }
    /// <summary>
    ///     ModelClientValidationCustomCompareRule class
    /// </summary>
    private class ModelClientValidationCustomDateRangeRule : ModelClientValidationRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelClientValidationCustomDateRangeRule"/> class.
        /// </summary>
        /// <param name="errorMessage">error message</param>
        /// <param name="dateRangeType">Type of the date range.</param>
        /// <param name="minDateProperty">The minimum date property.</param>
        /// <param name="currentProperty">The current property.</param>
        /// <param name="maxDateProperty">The maximum date property.</param>
        public ModelClientValidationCustomDateRangeRule(
            string errorMessage,
            CustomDateRangeType dateRangeType,
            string minDateProperty,
            string currentProperty,
            string maxDateProperty)
        {
            this.ErrorMessage = errorMessage;
            this.ValidationType = "customdaterange";
            this.ValidationParameters.Add("daterangetypeproperty", dateRangeType.ToString());
            this.ValidationParameters.Add("mindateproperty", minDateProperty);
            this.ValidationParameters.Add("currentproperty", currentProperty);
            this.ValidationParameters.Add("maxdateproperty", maxDateProperty);
        }
    }
    }
