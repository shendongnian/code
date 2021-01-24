    public class BootstrapDropDown : WebControl, INamingContainer
    {
        private DropDownList inputControl;
    
        public string DataTextField
        {
            get => (string)ViewState[nameof(DataTextField)];
            set => ViewState[nameof(DataTextField)] = value;
        }
        public string DataValueField
        {
            get => (string)ViewState[nameof(DataValueField)];
            set => ViewState[nameof(DataValueField)] = value;
        }
    
        public IEnumerable DataSource { get; set; }
    
        public virtual ListItemCollection Items
        {
            get
            {
                EnsureChildControls();
                return inputControl.Items;
            }
        }
    
        public virtual string Value
        {
            get
            {
                EnsureChildControls();
                return inputControl.SelectedValue;
            }
            set
            {
                EnsureChildControls();
                inputControl.SelectedValue = value;
            }
        }
    
        public virtual string Text
        {
            get
            {
                EnsureChildControls();
                return inputControl.SelectedItem?.Text;
            }
        }
    
        protected override void CreateChildControls()
        {
            /* Added other html markup controls described above */
    
            var validatorContainer = new HtmlGenericControl("div");
            validatorContainer.Attributes["class"] = "validator-container";
    
            inputControl = new DropDownList() {
                CssClass = "form-control selectpicker show-tick " + ID,
                ID = ID,
                DataValueField = DataValueField,
                DataTextField = DataTextField,
                DataSource = DataSource
            };
    
            inputControl.Attributes["data-size"] = "15";
            inputControl.Attributes["data-live-search"] = "true";
    
            validatorContainer.Controls.Add(inputControl);
    
            Controls.Add(validatorContainer);
    
            if (DataSource != null)
            {
                inputControl.DataBind();
            }
    
            /* Added other html markup controls described */
        }
    }
