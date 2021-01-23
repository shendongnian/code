        /// <summary>
        /// Handles Check Box State if Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxBidSummaryItem_Validated(object sender, EventArgs e)
        {
            // Code to execute...
            _MyEntity.Save(_businessObject.SelectedBid);
        }
