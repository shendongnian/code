    if (numberOfAvaiableTickets < numberOfTickets)
    {
        MessageBox.Show("Number of tickets exceeded", "ErrorWindow");
    }
    else
    {
         pay = 100 * numberOfTickets;
         Console.WriteLine("Pay please");
         Console.WriteLine(pay);
    }
