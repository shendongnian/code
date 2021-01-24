    public class CustomEntry : PXGraph<CustomEntry>
    {
	 [PXQuickProcess.Step.IsBoundToAttribute(typeof(UsrPath.SO303000.Balanced.Report.PrintLabelReport), false)][PXQuickProcess.Step.RequiresStepsAttribute(typeof(SOQuickProcessParameters.prepareInvoice))]
	 [PXQuickProcess.Step.IsInsertedJustAfterAttribute(typeof(SOQuickProcessParameters.prepareInvoice))]
	 [PXQuickProcess.Step.IsApplicableAttribute(typeof(Where<Current<SOOrderType.behavior>, In3<SOOrderTypeConstants.salesOrder, SOOrderTypeConstants.invoiceOrder, SOOrderTypeConstants.creditMemo>, And<Current<SOOrderType.aRDocType>, NotEqual<ARDocType.noUpdate>>>))]
	 protected virtual void SOQuickProcessParameters_PrintInvoice_CacheAttached(PXCache sender)
	 {
	 }
    }
    public static class UsrPath
    {
	 public static class SO303000
	 {
		public static readonly Type GroupGraph = typeof(SOInvoiceEntry);
		public static class Balanced
		{
			public const string GroupStepID = "Balanced";
			public static class Report
			{
				public const string GroupActionID = "Report";
				public class PrintLabelReport : PXQuickProcess.Step.IDefinition
				{
					public Type Graph
					{
						get
						{
							return UsrPath.SO303000.GroupGraph;
						}
					}
					public string StepID
					{
						get
						{
							return "Balanced";
						}
					}
					public string ActionID
					{
						get
						{
							return "Report";
						}
					}
					public string MenuID
					{
						get
						{
							return "Print Label";
						}
					}
					public string OnSuccessMessage
					{
						get
						{
							return "<Invoice form> is prepared";
						}
					}
					public string OnFailureMessage
					{
						get
						{
							return "Preparing Invoice form";
						}
					}
				}
			}
	 	 }
	  }
    }
