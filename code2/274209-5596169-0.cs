    void UpdateModemBaudRates(int baudRate)
    {
        foreach(PciCardSlot slot in pciSlotsInComputer)
        {
            Modem modem = slot.CardInSlot as Modem;
            if(modem != null)
            {
                modem.BaudRate = baudRate
            }
        }
    }
