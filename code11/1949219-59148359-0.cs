    public void PrintSoldTicket(SoldTicketDTO ticketDto)
    {
        SoldTicket soldTicket = CreateSoldTicket(ticketDto);
        var composer = new TicketComposer();
        TicketToPrint ticketToPrint = composer.ComposeTicketToPrint(soldTicket);
        var printer = new TicketPrinter();
        printer.Print(ticketToPrint);
    }
