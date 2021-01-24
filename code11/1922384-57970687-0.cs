    private static readonly int beginIndex = 20;
    
    private void Delimite_Btn_Click(object sender, RoutedEventArgs e)
    {
        string barcode = Original_Code_TxtBox.Text;
        int endIndex = barcode.Length - 5;
        
        if (endIndex > beginIndex)
        {
            var selectedText = barcode.Substring(beginIndex, endIndex - beginIndex);
        }
    }
