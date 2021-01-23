            var items = typeof(PageHeader).GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
            string fieldsNames = "";
            foreach (System.Reflection.FieldInfo fld in items)
            {
                fieldsNames += fld.Name + "\n";
            }
            MessageBox.Show(fieldsNames);
