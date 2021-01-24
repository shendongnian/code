int n = 4; // label counts
private void btnShow_Click(object sender, EventArgs e)
{
    
    Label[] labels = new Label[n];
    for (int i = 0; i < n; i++)
    {        
        labels[i] = new Label();
        // Here you can modify the value of the label which is at labels[i]
    }
    // add labels to Controls container
    for (int i = 0; i < n; i++)
    {
        this.Controls.Add(labels[i]);
    }
