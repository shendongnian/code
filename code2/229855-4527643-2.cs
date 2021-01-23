    class MyForm : ICriteriaView {
        public void ProcessCriteria(IChoices criteria) {
            this.SaveMultipleChoiceValue(criteria);
        }
        public void ProcessCriteria(ITextCriteria criteria) {
            // do nothing
        }
        private void SaveMultipleChoiceValues(IChoices criteria)
        {
            foreach (DataGridViewRow row in dgvCriteriaControls.Rows)
            {
                if (row == dgvCriteriaControls.Rows[dgvCriteriaControls.Rows.Count - 1])
                    continue;
                //multipleChoice.AddChoice(row.Cells["Name"].Value.ToString());
                string choice = row.Cells["Name"].Value.ToString();
                criteria.AddChoice(choice);
            }
        }
    }
