        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            e.Value = GetDescription(e.Value);
        }
        public static string GetDescription(object item)
        {
            string desc = null;
            Type type = item.GetType();
            MemberInfo[] memInfo = type.GetMember(item.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    desc = (attrs[0] as DescriptionAttribute).Description;
                }
            }
            if (desc == null) // Description not found
            {
                desc = item.ToString();
            }
            return desc;
        }
