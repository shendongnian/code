int voteTotal = 0;
int secondcolumn = 1;
    enter code here
if (votesListView.Items.Count < 1)
    MessageBox.Show("List View can not be  empty.");
else
    {
    for(int spot = 0; spot < votesListView.Items.Count; spot++)
        {
        voteTotal += int.Parse(votesListView.Items[spot].SubItems[secondcolumn].Text);
        //This will pop up a MessageBox at each iteration of this for loop.
        //feel free to comment out the MessageBox if it doesn't work.
        //you can also print out the voteTotal after the for loop.
        MessageBox.Show(spot.ToString());
        }
    }
