    public static readonly int CUSTOM_PROPERTY_ID = -10;
    private class CustomPTagWorker : PTagWorker {
        public CustomPTagWorker(IElementNode element, ProcessorContext context) : base(element, context) {
        }
        public override void ProcessEnd(IElementNode element, ProcessorContext context) {
            base.ProcessEnd(element, context);
            IPropertyContainer elementResult = GetElementResult();
            if (elementResult != null && !String.IsNullOrEmpty(element.GetAttribute(AttributeConstants.CLASS))) {
                elementResult.SetProperty(CUSTOM_PROPERTY_ID, element.GetAttribute(AttributeConstants.CLASS));
            }
        }
    }
