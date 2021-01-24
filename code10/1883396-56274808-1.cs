    public class Medewerker
    {
        //instantie variabelen
        public int id {get;}
        public string naam {get; set;}
        public string functie {get; set;}
        public DateTime datum_in_dienst {get; set;}
        public string telefoonnummer {get; set;}
        public string email {get; set;}
        public string wachtwoord {get; set;}
        public int hotelid {get; set;}
        public int managementid {get; set;}
        //constructor
        public Medewerker(int id, string naam, string functie, DateTime datum_in_dienst, string telefoonnummer, string email, string wachtwoord, int hotelid, int mangementid)
        {
            Id = id;
            Naam = naam;
            Functie = functie;
            Datum_in_dienst = datum_in_dienst;
            Telefoonnummer = telefoonnummer;
            Email = email;
            Wachtwoord = wachtwoord;
            Hotelid = hotelid;
            Managementid = managementid;
        }
    
        public static void UpdateSchoonmaker()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update medewerker set medewerkerid = " + this.id + ", naam ='" + this.naam + "',functie ='" + this.functie + "',datum_in_dienst = '" + this.datum_in_dienst + "',telefoonnummer =" + this.telefoonnummer + ",email ='" + this.email + "', wachtwoord ='" +this.wachtwoord+ "',hotelid = "+this.hotelid+", managementid ="+this.managementid+" where medewerkerid =" + id, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
