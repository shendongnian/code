namespace Vjezba6_1_v2
{
    class Osoba
    {
        public Podaci povr { get; set; }
        public Osoba(string tempIme, string tempPrezime, int tempOib)
        {
            this.povr.ime = tempIme;
            this.povr.prezime = tempPrezime;
            this.povr.oib = tempOib;
        }
    }
}
