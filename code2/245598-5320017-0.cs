    public class MyDropDown: WebControl, INamingContainer
    {
        private DropDownList _dropDown;
        private RequiredFieldValidator _validator;
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            Controls.Clear();
            _dropDown = new DropDownList();
            _dropDown.ID = ID + "_ddl";
            Controls.Add(_dropDown);
            _validator = new RequiredFieldValidator();
            _validator.ID = ID + "_Validator";
            _validator.ControlToValidate = _dropDown.ClientID;
            _validator.InitialValue = String.Empty;
            _validator.ErrorMessage = "*";
            _validator.ForeColor = Color.Red;
            Controls.Add(_validator);
        }
        //etc.
    }
