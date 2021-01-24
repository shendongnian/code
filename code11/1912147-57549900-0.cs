csharp
private void TestBox_TextChanged(object sender, TextChangedEventArgs e)
{
    if (TestBox.Text.Length == 1)
    {
        TestBox.SelectionStart = TestBox.Text.Length;
        TestBox.SelectionLength = 0;
    }
}
Best regards.
