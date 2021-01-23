                try
            {
                // usings here
                web.AllowUnsafeUpdates = true;
                SPLimitedWebPartManager man = web.GetLimitedWebPartManager("FormServerTemplates/Statistica.aspx", PersonalizationScope.Shared);
                ContentEditorWebPart wp = new ContentEditorWebPart();
                wp.ID = "newlyCreatedWP";
                man.AddWebPart(wp, this.Zone.ID, 2);
                web.AllowUnsafeUpdates = false;
                web.Update();
            }
            catch (Exception e)
            {
                Label l = new Label();
                l.Text = e.Message;
                this.Controls.Add(l);
            }
