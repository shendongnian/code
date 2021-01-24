`
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
namespace OutlookToMatter {
    partial class lfMatterForm {
        private static string PR_RECEIVED_BY_NAME = "http://schemas.microsoft.com/mapi/proptag/0x0040001E";
        private static string PR_SENT_REPRESENTING_NAME = "http://schemas.microsoft.com/mapi/proptag/0x0042001E";
        private static string PR_REPLY_RECIPIENT_NAMES = "http://schemas.microsoft.com/mapi/proptag/0x0050001E";
        private static string PR_SENT_REPRESENTING_EMAIL_ADDRESS = "http://schemas.microsoft.com/mapi/proptag/0x0065001E";
        private static string PR_RECEIVED_BY_EMAIL_ADDRESS = "http://schemas.microsoft.com/mapi/proptag/0x0076001E";
        private static string PR_TRANSPORT_MESSAGE_HEADERS = "http://schemas.microsoft.com/mapi/proptag/0x007D001E";
        private static string PR_SENDER_NAME = "http://schemas.microsoft.com/mapi/proptag/0x0C1A001E";
        private static string PR_SENDER_EMAIL_ADDRESS = "http://schemas.microsoft.com/mapi/proptag/0x0C1F001E";
        private static string PR_DISPLAY_BCC = "http://schemas.microsoft.com/mapi/proptag/0x0E02001E";
        private static string PR_DISPLAY_CC = "http://schemas.microsoft.com/mapi/proptag/0x0E03001E";
        private static string PR_DISPLAY_TO = "http://schemas.microsoft.com/mapi/proptag/0x0E04001E";
        private static string PR_CONVERSATION_INDEX = "http://schemas.microsoft.com/mapi/proptag/0x00710102";
        private static string PR_CONVERSATION_ID = "http://schemas.microsoft.com/mapi/proptag/0x30130102";
        public static string PR_INTERNET_MESSAGE_ID = "http://schemas.microsoft.com/mapi/proptag/0x1035001E";
        public static string PR_INTERNET_REFERENCES_ID = "http://schemas.microsoft.com/mapi/proptag/0x1039001E";
        private string site_job_tag = "http://schemas.microsoft.com/mapi/string/{00020386-0000-0000-C000-000000000046}/" + ThisAddIn.settings.site_job_tag;
        private job_lookup jl;
        Outlook.MailItem mailItem;
        #region Form Region Factory 
        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Note)]
        [Microsoft.Office.Tools.Outlook.FormRegionName("OutlookToMatter.LegalFirst")]
        public partial class lfMatterFormFactory {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void lfMatterFormFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e) {
            }
        }
        #endregion
        // Occurs before the form region is displayed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void lfMatterForm_FormRegionShowing(object sender, System.EventArgs e) {
            mailItem = (Outlook.MailItem)this.OutlookItem;
            var mProp = mailItem.PropertyAccessor;
            string jobRef = "";
            string origJobRef = "";
            byte[] pr_conv_id = new byte[16];
            byte[] orig_conv_id = new byte[16];
            try {
                if (ThisAddIn.previous_job_mnemonic != "") {
                    prev_job_mnemonic.Text = ThisAddIn.previous_job_mnemonic;
                    lfMatterTooltip.SetToolTip(prev_job_mnemonic, ThisAddIn.previous_job_name);
                }
                try {
                    jobRef = mProp.GetProperty(site_job_tag);
                } catch (Exception ex) {
                    jobRef = "";
                }
                try {
                    // Every message (except a New mailItem) seems to have a PR_CONVERSATION_INDEX
                    // but not always a PR_CONVERSATION_ID - so extract the PR_CONVERSATION_ID from the PR_CONVERSATION_INDEX
                    byte[] ci = mProp.GetProperty(PR_CONVERSATION_INDEX);
                    for (int i = 0; i < pr_conv_id.Length; i++) pr_conv_id[i] = ci[i+6];
                    //System.Diagnostics.Debug.WriteLine($"pi1: {pr_conv_id.Length}");
                } catch (Exception ex) {
                    System.Diagnostics.Debug.WriteLine($"pi1: {ex.Message}");
                }
                //try { // Not every message has one
                //    byte[] ci = mProp.GetProperty(PR_CONVERSATION_ID);
                //    System.Diagnostics.Debug.WriteLine($"pi2: {ci.Length}");
                //} catch (Exception ex) {
                //    System.Diagnostics.Debug.WriteLine($"pi2: {ex.Message}");
                //}
                // Find the selected mail item and obtain some properties
                var app = mailItem.Application;
                try {
                    if (app.ActiveExplorer().Selection.Count > 0) {
                        Object selObject = app.ActiveExplorer().Selection[1];
                        if (selObject is Outlook.MailItem) {
                            Outlook.MailItem selItem = (selObject as Outlook.MailItem);
                            var sProp = selItem.PropertyAccessor;
                            try {
                                origJobRef = sProp.GetProperty(site_job_tag);
                            } catch (Exception ex) {
                                origJobRef = "";
                            }
                            try {
                                byte[] ci = sProp.GetProperty(PR_CONVERSATION_INDEX);
                                for (int i = 0; i < orig_conv_id.Length; i++) orig_conv_id[i] = ci[i + 6];
                                //System.Diagnostics.Debug.WriteLine($"pi01: {orig_conv_id.Length}");
                            } catch (Exception ex) {
                                System.Diagnostics.Debug.WriteLine($"pi01: {ex.Message}");
                            }
                            // Decide if this mail item is related to (but not the same as) the selected mail item
                            if (selItem.EntryID != mailItem.EntryID && orig_conv_id.SequenceEqual(pr_conv_id) && origJobRef != "" && jobRef == "") {
                                // The selected mail item is related to the one showing in the formRegion and has the job reference property
                                // Copy the job reference property from the originating message
                                jobRef = origJobRef;
                            }
                        }
                    }
                } catch (Exception ex) {
                    System.Diagnostics.Debug.WriteLine($"Current Inbox {ex.Message}");
                }
// Remaining code not relevant.
`
