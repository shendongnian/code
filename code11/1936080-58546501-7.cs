    public class DynamicDataTemplateCreator : DataTemplateSelector
    {
        //  If mainwindow or the main viewmodel has information that we need about the 
        //  dynamically loaded views, pass that information via this property. It can be any 
        //  type you want, preferably the exact type of the information you are passing.
        public object ViewLookupInformation { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //  item is the viewmodel.
            Type viewType = null;
            //  A quickie UserControl I wrote for testing. 
            //viewType = typeof(VMView);
            /* 
             * logic here to determine the type of view we want. Assign that Type to viewType
             *  If you need extra information from the main program, smuggle it in to here via 
             *  ViewLookupInformation
             */
            return new DataTemplate
            {
                VisualTree = new FrameworkElementFactory(viewType)
            };
        }
    }
