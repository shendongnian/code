    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
    
    
    namespace MyCompany.Applications.MyApplication.BusinessLogic.Validation.MyType1Validations
    {
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
        public class BookExistsValidatorAttribute : ValidatorAttribute
        {
            protected override Validator DoCreateValidator(Type targetType)
            {
                return new BookExistsValidator("BookExistsValidatorTag");
            }
        }
    
        public class BookExistsValidator : Validator<string>
        {
    
            public BookExistsValidator(string tag) : base("BookExistsValidatorMessageTemplate", tag) { }
    
            protected override string DefaultMessageTemplate
            {
                get { throw new NotImplementedException(); }
            }
    
            protected override void DoValidate(string objectToValidate, object currentTarget, string key, ValidationResults validationResults)
            {
    
                bool bookExists = BookMatchExists(objectToValidate);
    
                if (!bookExists)
                {
    				string msg = string.Format("The Book does not exist.  Your ISBN='{0}'", objectToValidate);
                    validationResults.AddResult(new ValidationResult(msg, currentTarget, key, 10001, this)); /* 10001 is just some number I made up */
    
                }
    
    
            }
    
            private bool BookMatchExists(string isbn)
            {
                bool returnValue = false;
    
                IBookCollection coll = MyCompany.Applications.MyApplication.BusinessLogic.CachedControllers.BookController.FindAll(); /* Code not shown, but this would hit the db and return poco objects of books*/
    
                IBook foundBook = (from item in coll where item.ISBN.Equals(book, StringComparison.OrdinalIgnoreCase) select item).SingleOrDefault();
    
                if (null != foundBook)
                {
                    returnValue = true;
                }
                return returnValue;
            }
    
    
    
        }
    }
