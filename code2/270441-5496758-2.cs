     protected void Downloadbtn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            GridViewRow clickedGridViewRow = (GridViewRow)clickedButton.Parent.Parent;
            string x = clickedGridViewRow.Cells[AnotherCellNumberInTheSameRowWhoseValueYouWantToGet].Text;
         }
