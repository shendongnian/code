    public class CheckBoxList_Extended : CheckBoxList
    {
        /// <summary>
        /// Gets or sets the name of the data property to bind to the tooltip attribute of the individual CheckBox.
        /// </summary>
        [DefaultValue("")]
        public string DataTooltipField
        {
            get
            {
                string value = base.ViewState["DataTooltipField"] as string;
                if (value == null)
                    value = "";
                return value;
            }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    base.ViewState.Remove("DataTooltipField");
                }
                else
                {
                    base.ViewState["DataTooltipField"] = value.Trim();
                }
            }
        }
        /// <summary>
        /// Gets or sets the name of the data property to bind to the Checked property of the individual CheckBox.
        /// </summary>
        [DefaultValue("")]
        public string DataCheckedField
        {
            get
            {
                string value = base.ViewState["DataCheckedField"] as string;
                if (value == null)
                    value = "";
                return value;
            }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    base.ViewState.Remove("DataCheckedField");
                }
                else
                {
                    base.ViewState["DataCheckedField"] = value.Trim();
                }
            }
        }
        protected override void PerformDataBinding(System.Collections.IEnumerable dataSource)
        {
            if (dataSource != null)
            {
                string dataSelectedField = this.DataCheckedField;
                string dataTextField = this.DataTextField;
                string dataTooltipField = this.DataTooltipField;
                string dataValueField = this.DataValueField;
                string dataTextFormatString = this.DataTextFormatString;
                bool dataBindingFieldsSupplied = (dataTextField.Length != 0) || (dataValueField.Length != 0);
                bool hasTextFormatString = dataTextFormatString.Length != 0;
                bool hasTooltipField = dataTooltipField.Length != 0;
                bool hasSelectedField = dataSelectedField.Length != 0;
                if (!this.AppendDataBoundItems)
                    this.Items.Clear();
                if (dataSource is ICollection)
                    this.Items.Capacity = (dataSource as ICollection).Count + this.Items.Count;
                foreach (object dataItem in dataSource)
                {
                    ListItem item = new ListItem();
                    if (dataBindingFieldsSupplied)
                    {
                        if (dataTextField.Length > 0)
                        {
                            item.Text = DataBinder.GetPropertyValue(dataItem, dataTextField, null);
                        }
                        if (dataValueField.Length > 0)
                        {
                            item.Value = DataBinder.GetPropertyValue(dataItem, dataValueField, null);
                        }
                    }
                    else
                    {
                        if (hasTextFormatString)
                        {
                            item.Text = string.Format(CultureInfo.CurrentCulture, dataTextFormatString, new object[] { dataItem });
                        }
                        else
                        {
                            item.Text = dataItem.ToString();
                        }
                        item.Value = dataItem.ToString();
                    }
                    if (hasSelectedField)
                    {
                        item.Selected = (bool)DataBinder.GetPropertyValue(dataItem, dataSelectedField);
                    }
                    if (hasTooltipField)
                    {
                        string tooltip = DataBinder.GetPropertyValue(dataItem, dataTooltipField, null);
                        if (tooltip != null && tooltip.Trim() != "")
                        {
                            item.Attributes["title"] = tooltip;
                        }
                    }
                    this.Items.Add(item);
                }
            }
            base.PerformDataBinding(null);
        }
    }
