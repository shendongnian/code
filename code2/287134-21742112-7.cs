      using System;
      using System.Collections.Generic;
      using System.ComponentModel;
      using System.ComponentModel.DataAnnotations;
      public class Program
      {
         public static void Main()
         {
            var customer = new Customer();
            TypeDescriptor.AddProviderTransparent(
              new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Customer), 
                typeof(ICustomerMetaData)), 
                typeof(Customer));
            var context = new ValidationContext(customer);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(
              customer, context, validationResults, true);
            Console.WriteLine($"is Valid = {isValid}");
            customer.Title = "I has Title";
            isValid = Validator.TryValidateObject(
              customer, context, validationResults, true);
            Console.WriteLine($"is Valid = {isValid}");
            Console.ReadKey();
         }
         [MetadataType(typeof(ICustomerMetaData))]
         public partial class Customer
         {
            public string Title { get; set;  }
         }
         public interface ICustomerMetaData
         {
            // Apply RequiredAttribute
            [Required(ErrorMessage = "Title is required.")]
            string Title { get; }
         }
      }
