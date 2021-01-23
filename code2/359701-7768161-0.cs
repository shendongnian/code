    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenXmlPowerTools;
    using DocumentFormat.OpenXml.Packaging;
    class Program
    {
        static void Main(string[] args)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open("Test.docx", true))
            {
	            SimplifyMarkupSettings settings = new SimplifyMarkupSettings
	            {
		            RemoveComments = true,
		            RemoveContentControls = true,
		            RemoveEndAndFootNotes = true,
		            RemoveFieldCodes = false
		            RemoveLastRenderedPageBreak = true,
		            RemovePermissions = true,
		            RemoveProof = true,
		            RemoveRsidInfo = true,
		            RemoveSmartTags = true,
		            RemoveSoftHyphens = true,
		            ReplaceTabsWithSpaces = true,
	            };
	            MarkupSimplifier.SimplifyMarkup(doc, settings);
            }
        }
    }
