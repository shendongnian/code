private void Next_Click(object sender, EventArgs e)
{            
    switch (i++ % 4)
    {
        case 0:
            red.BackColor = Color.Red;
            orange.BackColor = Color.Black;
            green.BackColor = Color.Black;
            break;
        case 1:
            red.BackColor = Color.Red;
            oragne.BackColor = Color.Orange;
            green.BackColor = Color.Black;
            break;
        case 2:
            red.BackColor = Color.Black;
            orange.BackColor = Color.Black;
            green.BackColor = Color.Green;
            break;
        case 3:
            red.BackColor = Color.Black;
            orange.BackColor = Color.Orange;
            green.BackColor = Color.Black;
            break;
    }
}
More reading here: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators
