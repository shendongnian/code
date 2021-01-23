    using System.ComponentModel.DataAnnotations;
    public class ControlValidationHelper
    {
        private string _message;
    
        public ControlValidationHelper(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
    
            _message = message;
            ThrowValidationError = true;
        }
    
        public bool ThrowValidationError
        {
            get;
            set;
        }
    
        public object ValidationError
        {
            get { return null; }
            set
            {
                if (ThrowValidationError)
                {
                    throw new ValidationException(_message);
                }
            }
        }
    } 
