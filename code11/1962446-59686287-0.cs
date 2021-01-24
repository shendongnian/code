                    Console.WriteLine("Search by surname (2)");
                    Console.WriteLine("Input surname (prezime):");
                    string pPrezime = Console.ReadLine();
                    List<PoliceOsiguranja> lPoliceOsiguranja = DohvatiPoliceOsiguranja();
                    List<Klijent> lKlijent = DohvatiKlijente();
                    int RedniBr = 1;
                    foreach (var Klijent in lKlijent)
                    {
                        if (Klijent.prezime == pPrezime)
                        {
                            Console.WriteLine("Client based on OIB: " + Klijent.OIB + " - " + Klijent.ime + " " + Klijent.prezime + " " + Klijent.grad);
                        }
                    }
                    Console.WriteLine("Created insurance policies:");
                    var tablica = new ConsoleTable("Order number(RedniBr). ", "Policy number", "Type of insurance", "Date", "Date", "Value");
                    foreach (var PoliceOsiguranja in lPoliceOsiguranja)
                    {
                        if (PoliceOsiguranja.Prezime == pPrezime)
                        {
                            tablica.AddRow(RedniBr++ + ".", PoliceOsiguranja.BrojPolice, PoliceOsiguranja.VrstaOsiguranja, PoliceOsiguranja.DatumPocetka, PoliceOsiguranja.DatumIsteka, PoliceOsiguranja.Vrijednost);
                        }
                    }
