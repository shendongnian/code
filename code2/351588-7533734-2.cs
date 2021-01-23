    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    public class Employee : StringConverter
    {
        DataClasses1DataContext mydb = new DataClasses1DataContext();
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var a = (from u in mydb.Customers select u.CustomerID).ToArray();
            return new StandardValuesCollection(a);
        }
        public string Name { get; set; }
        [TypeConverter(typeof(Employee)), CategoryAttribute("Document Settings")]
        public string DepartmentID { get; set; }
    }
