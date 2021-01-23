    public class TableModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = base.BindModel(controllerContext, bindingContext) as ITableModel;
            if (result != null)
                result.UpdateSorter();
            return result;
        }
    }
