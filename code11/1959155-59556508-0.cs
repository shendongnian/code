        private void btnClassify_Click(object sender, EventArgs e)
        {
            // remove any existing rows, we will reprocess all records.
            this.dGvTopics.Rows.Clear();
            // Iterate over the rows in the list of sentences.
            for (int rowIndex = 0; rowIndex < dataGridView2.Rows.Count; rowIndex++)
            {
                // save the sentence value to simplify the comparison code.
                string currentSentence = dataGridView2.Rows[rowIndex].Cells[0].Value.ToString();
                // iterate over the columns in the topics grid
                for (int columnIndex = 0; columnIndex < dGvTopics.Columns.Count; columnIndex++)
                {
                    if (currentSentence.Contains(dGvTopics.Columns[columnIndex].HeaderText))
                    {
                        // first we need to know what row index to add this value into
                        // that involves another iteration, we could store last index in another structure to make this quicker, but here we will do it from first principals.
                        bool inserted = false;
                        for (int lookupRow = 0; lookupRow < this.dGvTopics.Rows.Count; lookupRow++)
                        {
                            // find the first row with a null cell;
                            if (this.dGvTopics.Rows[lookupRow].Cells[columnIndex].Value == null)
                            {
                                this.dGvTopics.Rows[lookupRow].Cells[columnIndex].Value = currentSentence;
                                inserted = true;
                                break;
                            }
                        }
                        if (!inserted)
                        {
                            this.dGvTopics.Rows.Add();
                            this.dGvTopics.Rows[this.dGvTopics.Rows.Count - 1].Cells[columnIndex].Value = currentSentence;
                        }
                    }
                }
            }
        }
