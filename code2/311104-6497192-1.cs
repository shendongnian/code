    private void ASAtoHyperlinkCompose()
       {                                           
           var uiInspector = Application.ActiveInspector;
           var uiObject = uiInspector.CurrentItem;
           if (uiObject.MessageClass.ToString().Equals("IPM.Note") && uiInspector.IsWordMail)
           {
               var uiItem = uiInspector.CurrentItem;
               var uiDoc = uiInspector.WordEditor;
               uiDoc.Range.Find.Text = "ASA^$^$^#^#^#^#^#";
               while (uiDoc.Range.Find.Execute())
               {
                   uiDoc.Range.Find.Parent.Hyperlinks.Add(uiDoc.Range.Find.Parent, string.Format(@"http://stack.com={0}outlook2007", uiDoc.Range.Find.Parent.Text));
                   uiDoc.Range.Find.Parent.Collapse(wdCollapseEnd);
               }
           }
       }
