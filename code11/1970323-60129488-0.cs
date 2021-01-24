        private void btnCopyStyles_Organizer_Click(object sender, EventArgs e)
        {
            string tmplPath  = @"C:\Test\StylesTemplate.dotm";
            string[] aStyles = {"Heading 1", "Heading 2" };
            for (int i = 0; i == aStyles.Length- 1; i++)
            {
                wdApp.OrganizerCopy(tmplPath, wdApp.ActiveDocument.FullName, aStyles[i],
                    Word.WdOrganizerObject.wdOrganizerObjectStyles);
            }
        }
