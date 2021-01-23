     protected override void OnInit(EventArgs e)
        {
            UpdatePanel updatePanel = new UpdatePanel();
            //updatePanel.ContentTemplateContainer.Controls.Add(linkButton); if want to add control in UpdatePanel
            form1.Controls.Add(updatePanel);
            base.OnInit(e);
        }
