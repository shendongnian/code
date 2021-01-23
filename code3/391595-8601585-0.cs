    void lnk1_Click(object sender)
    {
        Button clickedLinkButton = sender as Button;
        String buttonText = clickedLinkButton .Text;
        String clickedTicketNumber = 
                                      buttonText
                                      .SubString(0, buttonText.IndexOf(':'))
                                      .Trim();"    
    }
