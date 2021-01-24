        private void Show_PopupBillingPreview(object sender, MouseEventArgs e)
        {
            var listViewItem = e.Source as ListViewItem;
            var billing = listViewItem?.Content as Billing;
            PuBillingPreviewTitle.Text = billing?.BillingId.ToString();
            PuBillingPreview.PlacementTarget = listViewItem;
            PuBillingPreview.Placement = PlacementMode.MousePoint;
            PuBillingPreview.IsOpen = true;
        }
        private void Hide_PopupBillingPreview(object sender, MouseEventArgs e)
        {
            if (PuBillingPreview.IsOpen)
                PuBillingPreview.IsOpen = false;
        }
