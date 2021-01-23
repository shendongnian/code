    using (PrintServer ps = new PrintServer()) {
        using (PrintQueue pq = new PrintQueue(ps, printerName,
              PrintSystemDesiredAccess.AdministratePrinter)) {
            pq.Purge();
        }
    }
