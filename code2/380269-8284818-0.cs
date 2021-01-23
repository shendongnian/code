    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // setup test object
                Test t = new Test() { Age = 16, IsOld = true };
                // store validation results
                Collection<ValidationResult> validationResults = new Collection<ValidationResult>();
                // run validation
                if (Validator.TryValidateObject(t, new ValidationContext(t, null, null), validationResults, true))
                {
                    // validation passed
                    Console.WriteLine("All items passed validation");
                }
                else
                {
                    // validation failed
                    foreach (var item in validationResults)
                    {
                        Console.WriteLine(item.ErrorMessage);
                    }
                }
                Console.ReadKey(true);
            }
        }
        [TestValidation(ErrorMessage = "Test object is not valid")]
        public class Test
        {
            public int Age { get; set; }
            public bool IsOld { get; set; }
        }
        public class TestValidation : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                bool isValid = false;
                Test testVal = value as Test;
                if (testVal != null)
                {
                    // conditional logic here
                    if ((testVal.Age >= 21 && testVal.IsOld) || (testVal.Age < 21 && !testVal.IsOld))
                    {
                        // condition passed
                        isValid = true;
                    }
                }
                return isValid;
            }
        }
    }
