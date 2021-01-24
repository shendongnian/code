cs
public class TestModel
{
    [TestValidation("Hello world!", ErrorMessage = "You did not write Hello world!.")]
    [Display(Name = "Test Value")]
    public string TestValue { get; set; }
}
cs
    [AttributeUsage(AttributeTargets.Property)]
    public class TestValidationAttribute : ValidationAttribute, IClientModelValidator
    {
        private object _expectedValue;
        public TestValidationAttribute(object expectedValue)
        {
            _expectedValue = expectedValue;
        }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            return Equals(value, _expectedValue);
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-testvalidation", ErrorMessage);
            context.Attributes.Add("data-val-testvalidation-expectedvalue", _expectedValue.ToString());
        }
    }
> Note that, jQuery validation registers its rules before the DOM is loaded. If you try to register your adapter after the DOM is loaded, your rules will not be processed. So wrap it in a self-executing function.
js
$(function ($) {
    $.validator.addMethod('testvalidation', function (value, element, params) {
        var expectedValue = params.expectedvalue;
        if (!expectedValue) return false;
        var actual = element.value;
        if (actual === expectedValue) return true;
        return false;
    });
    $.validator.unobtrusive.adapters.add('testvalidation', ['expectedvalue'],
        function (options) {
            // Add validation rule for HTML elements that contain data-testvalidation attribute
            options.rules['testvalidation'] = {
                // pass the data from data-testvalidation-expectedvalue to
                // the params argument of the testvalidation method
                expectedvalue: options.params['expectedvalue']
        };
        // get the error message from data-testvalidation-expectedvalue
        // so that unobtrusive validation can use it when validation rule fails
        options.messages['testvalidation'] = options.message;
    });
}(jQuery));
The correct way of loading the scripts would be
html
@section Scripts{
    @Html.Partial("_ValidationScriptsPartial"); // Or instead like this:
    <!--<script src="~/lib/jquery-validation/dist/jquery.validate.js"></script>-->
    <!--<script src="~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js">-->
    <script src="~/js/testvalidation.js"></script>
}
