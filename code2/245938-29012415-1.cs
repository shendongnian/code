    public class CheckboxListExampleModel {
        public string TextboxValue { get; private set; }
        public List<int> CheckboxValues { get; private set; }
        public class Binder : DefaultModelBinder {
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
                var model = new CheckboxListExampleModel();
                model.TextboxValue = bindingContext.GetValueAsString("tBox");
                
                string checkboxCsv = bindingContext.GetValueAsString("cBox");
                // checkboxCsv will be a comma-separated list of the 'value' attributes
                //   of all the checkboxes with name "cBox" which were checked
                model.CheckboxValues = checkboxCsv.SplitCsv<int>();
                return model;
            }
        }
    }
