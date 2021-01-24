 C#
using Excel.DataBind;
using System;
using System.Collections.Generic;
using System.Reflection;
namespace Excel.DataBind
{
    public class ExcelDataBinder
    {
        public void DataBind(ExcelDocument doc, object target)
        {
            var lookup = new Dictionary<string, PropertyInfo>();
            // loop through all properties of the target.
            foreach(var prop in target.GetType().GetProperties())
            {
                // if the property has an decorator, store this.
                var address = prop.GetCustomAttribute<ExcelDataBindAttribute>()?.Address;
                if(!string.IsNullOrEmpty(address))
                {
                    lookup[address] = prop;
                }
            }
            // loop through all excel fields
            foreach(var field in doc)
            {
                // if a mapping is defined
                if(lookup.TryGetValue(field.Address, out var prop))
                {
                    // use reflection to set the value.
                    prop.SetValue(target, field.Value);
                }
            }
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelDataBindAttribute : Attribute
    {
        public ExcelDataBindAttribute(string address) => Address = address;
        public string Address { get; }
    }
}
namespace Excel.Models
{
    public class Model
    {
        [ExcelDataBind("A2")]
        public string Value { get; set; }
    }
}
This approach can also be used to to write to Excel based on a model of course.
Note that setting the value can be tricky. Your ExcelDocument representation might use different types than your model (decimal vs double etc.) In that case you have to convert that too.
Another remark: In my experience (I've written code like that in the past) in real world scenario's the model represent just a row of an excel sheet tab. Than you need something with an header row, and should be defensive on column orders. (You still need attributes to describe the relation between the Excel truth and you code truth however).
