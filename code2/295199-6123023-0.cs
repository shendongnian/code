    /// <summary>
    /// Event args for the validation error. 
    /// </summary>
    /// <typeparam name="ControlType">The control type accepted. (Can be 'Control´ for flexibility.</typeparam>
    public class EvalidationErrorEventArgs<ControlType> : System.EventArgs
        where ControlType : Control
    {
        ControlType ControlCausingException { get; private set; }
        public FormatException RaisedException { get; private set; }
        public EvalidationErrorEventArgs(ControlType controlCausingException, FormatException ex)
        {
            this.ControlCausingException = controlCausingException;
        }
    }
    /// <summary>
    /// The validation error event.
    /// </summary>
    /// <typeparam name="ControlType">The type of control to be communicated by the event.</typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ValidationErrorEvent<ControlType>(object sender, EvalidationErrorEventArgs<ControlType> e);
    /// <summary>
    /// Base validator, expects validation 
    /// errors to be communicated as a FormatException. 
    /// Other exception types are thrown.
    /// </summary>
    public abstract class TextBoxValidator
    {
        public event ValidationErrorEvent<TextBox> ValidationError;
        /// <summary>
        /// Do validation. Raises event if format exception 
        /// occurs and listeners are registered. 
        /// </summary>
        /// <param name="textBoxToValidate">Control to validate.</param>
        public void Validate(TextBox textBoxToValidate)
        {
            try
            {
                DoValidation(textBoxToValidate);
            }
            catch (FormatException e)
            {
                if (ValidationError != null)
                {
                    ValidationError(this, new EvalidationErrorEventArgs<TextBox>(textBoxToValidate, e));
                }
                else
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// Overwrite to implement the actual 
        /// validation.
        /// </summary>
        /// <param name="txt">Control to validate</param>
        protected abstract void DoValidation(TextBox txt);
    }
    /// <summary>
    /// Performs validation of input controls content. 
    /// </summary>
    public abstract class IsTextValidator : TextBoxValidator
    {
        /// <summary>
        /// Validates a text box to contain an integer value. 
        /// </summary>
        /// <param name="txt">Control to validate</param>
        protected override void DoValidation(TextBox txt)
        {
            int.Parse(txt.Text);
        }
    }
