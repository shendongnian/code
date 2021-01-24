private void btnClassify_Click(object sender, EventArgs e)
{
    // remove any existing rows, we will reprocess all records.
    this.dGvTopics.Rows.Clear();
    // Iterate over the rows in the list of sentences.
    for (int rowIndex = 0; rowIndex < dataGridView2.Rows.Count; rowIndex ++)
    {
        // Create one topic row for every sentence
        // row index will always be valid now.
        this.dGvTopics.Rows.Add();
        // save the sentence value to simplify the comparison code.
        string currentSentence = dataGridView2.Rows[rowIndex].Cells[0].Value.ToString();
        
        // iterate over the columns in the topics grid
        for (int columnIndex = 0; columnIndex < dGvTopics.Columns.Count; columnIndex ++)
        {
            if (currentSentence.Contains(dGvTopics.Columns[columnIndex].HeaderText))
            {
                this.dGvTopics.Rows[rowIndex].Cells[columnIndex].Value = currentSentence;
            }
        }
    }
}
---
It's not easy to comprehend _why_ you want to do this or how this information will be used. In general for manipulating values in cells we generally recommend that databinding techniques are used instead, that way you do not access rows and cells anymore or but the underlying objects that they represent.
- demonstrating this is outside of the scope of this question, but it's an avenue worth researching when you have time.
In solutions like this where there are two grids that represent the same logical component, (in this case each row in each grid represents the same sentence value) the underlying dataobject might be a single list, where one property on the object is the sentence and each topic column is a property on the _same_ object.
Importantly, using databinding means that the next process that needs to use the information that you have displayed or edited in the grids can do so without access to or knowledge about the grids at all... Something to think about ;)
Update
---
This code may result in many empty cells in the _topics_ grid. We could instead only add rows as they are needed, but to do this will require a lot more effort.
> __NOTE:__ Grids render all the cells for each _row_, In the last couple of rows, there may still be empty cells if at least one of the cells for that row has a value.
private void btnClassify_Click(object sender, EventArgs e)
{
    // remove any existing rows, we will reprocess all records.
    this.dGvTopics.Rows.Clear();
    // Iterate over the rows in the list of sentences.
    for (int rowIndex = 0; rowIndex < dataGridView2.Rows.Count; rowIndex ++)
    {
        // save the sentence value to simplify the comparison code.
        string currentSentence = dataGridView2.Rows[rowIndex].Cells[0].Value.ToString();
        // iterate over the columns in the topics grid
        for (int columnIndex = 0; columnIndex < dGvTopics.Columns.Count; columnIndex ++)
        {
            if (currentSentence.Contains(dGvTopics.Columns[columnIndex].HeaderText))
            {
                // first we need to know what row index to add this value into
                // that involves another iteration, we could store last index in another structure to make this quicker, but here we will do it from first principals.
                bool inserted = false;
                for(int lookupRow = 0; lookupRow < this.dGvTopics.Rows.Count; lookupRow ++)
                {
                    // find the first row with a null cell;
                    if(this.dGvTopics.Rows[columnIndex].Value == null)
                    {
                        this.dGvTopics.Rows[lookupRow].Cells[columnIndex].Value = currentSentence;
                        inserted = true;
                        break;
                    }
                }
                if(!inserted)
                {
                    this.dGvTopics.Rows.Add();
                    this.dGvTopics.Rows[this.dGvTopics.Rows.Count-1].Cells[columnIndex].Value = currentSentence;
                }
            }
        }
    }
}
