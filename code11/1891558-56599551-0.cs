    bool metinoysonuc = Double.TryParse(txt_metin.Text, out metinoy);
    bool oktayoysonuc = Double.TryParse(txt_oktay.Text, out oktayoy);
    bool fatihoysonuc = Double.TryParse(txt_fatih.Text, out fatihoy);
    bool terimoysonuc = Double.TryParse(txt_terim.Text, out terimoy);
    if (!metinoysonuc || !oktayoysonuc || !fatihoysonuc || !terimoysonuc)
    {
        // At least one parse operation failed.  Notify the user?
    }
