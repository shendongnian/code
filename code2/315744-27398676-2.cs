        void YourGridNameifItsInGrid_ShownEditor(object sender, EditorEventArgs e)
            {
                if (e.Editor is LookUpEdit)
                {
                    LookUpEdit lookupEdit = (LookUpEdit)e.Editor;
                    GridControl gGridControl = lookupEdit.GetGridControl();                  
                }
            }
