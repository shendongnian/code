        public void Afhalen(decimal bedrag)
        {
            NegatiefSaldoHasListeners(this.RekeningUittreksel, this.NegatiefSaldo);//calls  the contract abbreviator with delegate type parameters to check for Nullreference
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
        public void Storten(decimal bedrag)
        {
            UittrekselHasListeners(this.RekeningUittreksel);//calls the contract abbreviator with a delegate type (event) parameter to check for Nullreference
            
            VorigSaldo = Saldo;
            Saldo += bedrag;
            RekeningUittreksel(this);
            
        }
        public virtual void Afbeelden()
        {
            Console.WriteLine("Rekeningnr: {0:0000 0000 0000 0000}",Nummer);
            Console.WriteLine("Saldo:  {0}",Saldo);
            Console.WriteLine("Creatiedatum: {0:dd-MM-yyyy}",CreatieDatum);
        }
        [ContractAbbreviator]
        public void CheckArgs(string nummer, Klant eigenaar)
        {
            Contract.Requires<ArgumentException>(!String.IsNullOrWhiteSpace(nummer), "Geen nummer ingevuld!");
            Contract.Requires<FormatException>(nummer.Trim().Length == 16,"Ongeldig aantal tekens ingevoerd!");
            Contract.Requires<ArgumentException>(!String.IsNullOrWhiteSpace(eigenaar.ToString()), "Eigenaar niet opgegeven!");
        }
        
        [ContractAbbreviator]
        public void UittrekselHasListeners(Transactie actie)
        {
            Contract.Requires<NullReferenceException>(actie != null, "\n\nGeen event listener toegewezen!\n\n");
        }
        [ContractAbbreviator]
        public void NegatiefSaldoHasListeners(Transactie actie,Transactie actie2)
        {
            Contract.Requires<NullReferenceException>(actie != null, "\n\nGeen event listener toegewezen!\n\n");
            Contract.Requires<NullReferenceException>(actie2 != null, "\n\nGeen event listener toegewezen!\n\n");
        }
        
    
    
 
