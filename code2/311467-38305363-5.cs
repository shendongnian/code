    using System;
    using System.Windows.Forms;
    using System.ComponentModel;
    public static class ListBoxExtensions
    {
        public static object GetItemValue(this ListBox list, object item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            if (string.IsNullOrEmpty(list.ValueMember))
                return item;
            var property = TypeDescriptor.GetProperties(item)[list.ValueMember];
            if (property == null)
                throw new ArgumentException(
                    string.Format("item doesn't contain '{0}' property or column.",
                    list.ValueMember));
            return property.GetValue(item);
        }
    }
