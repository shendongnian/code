    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
       // This is the attribute that we will apply to the fields
       // for which we want to specify an option name.
       [AttributeUsage(AttributeTargets.Field)]
       public class OptionNameAttribute : Attribute
       {
          public OptionNameAttribute(string optionName)
          {
             OptionName = optionName;
          }
    
          public string OptionName { get; private set; }
       }
    
       // This is the class which will contain the option values that 
       // we read from the file.
       public class OptionContainer
       {
          [OptionName("Name")]
          public string MyNameField;
    
          [OptionName("Value")]
          public string MyValueField;
       }
    
       class Program
       {
          // SetOption is the method that assigns the value provided to the 
          // field of the specified instance with an OptionName attribute containing
          // the specified optionName.
          static void SetOption(object instance, string optionName, string optionValue)
          {
             // Get all the fields that has the OptionNameAttribute defined
             IEnumerable<FieldInfo> optionFields = instance.GetType()
                .GetFields()
                .Where(field => field.IsDefined(typeof(OptionNameAttribute), true));
    
             // Find the single field where the OptionNameAttribute.OptionName property
             // matches the provided optionName argument.
             FieldInfo optionField = optionFields.SingleOrDefault(field =>
                field.GetCustomAttributes(typeof(OptionNameAttribute), true)
                .Cast<OptionNameAttribute>().Single().OptionName.Equals(optionName));
    
             // If the found field is null there is no such option.
             if (optionField == null)
                throw new ArgumentException(String.Format("Unknown option {0}", optionName), "optionname");
    
             // Finally set the value.
             optionField.SetValue(instance, optionValue);
          }
    
          static void Main(string[] args)
          {
             OptionContainer instance = new OptionContainer();
             SetOption(instance, "Name", "This is the value of Name");
             SetOption(instance, "Value", "This is my value");
    
             Console.WriteLine(instance.MyNameField);
             Console.WriteLine(instance.MyValueField);
          }
       }
    }
