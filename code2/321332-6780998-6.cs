        // Extends the Combobox control so that it can be automatically bound to an Enum
        // that has been decorated with Description attributes.
        // Sets the current value of the combobox to the value of the enum instance passed in.
        public static void BindToDecoratedEnum(this System.Windows.Forms.ComboBox cb, Enum e)
        {
            // Clear the combobox
            cb.DataSource = null;
            cb.Items.Clear();
            // Bind the combobox
            cb.DataSource = new System.Windows.Forms.BindingSource(e.GetKeyValuePairs(), null);
            cb.DisplayMember = "Value";
            cb.ValueMember = "Key";
            cb.Text = e.GetAttribute<DescriptionAttribute>().Description;
        }
