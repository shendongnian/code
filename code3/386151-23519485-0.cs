    public delegate void Transactie(Rekening rekening);//signature for events
        public Transactie RekeningUittreksel;
        public Transactie NegatiefSaldo;
    
    public void Storten(decimal bedrag,Transactie actie)
        {
            Contract.Requires<NullReferenceException>(actie!=null,"\n\nGeen event listener toegewezen!\n\n");
            VorigSaldo = Saldo;
            Saldo += bedrag;
            RekeningUittreksel(this);
                
        }
     public void Afhalen(decimal bedrag,Transactie actie,Transactie actie2)
        {
            Contract.Requires<NullReferenceException>(actie!=null,"\n\nGeen event listener toegewezen!\n\n");
            Contract.Requires<NullReferenceException>(actie2 != null, "\n\nGeen event listener toegewezen!\n\n");
            VorigSaldo = Saldo;
            if (bedrag <= Saldo)
                {
                    Saldo -= bedrag;
                    RekeningUittreksel(this);
                }
                else
                {
                    NegatiefSaldo(this);
                }
        }
    
