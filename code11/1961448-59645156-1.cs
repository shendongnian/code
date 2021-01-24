    namespace WindowsFormsApplication58
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                SuiviEntretienMoto.Marque marque = new SuiviEntretienMoto.Marque();
                this.lesMarques.Items.AddRange(marque.lesMarques.Select(x => x.nomMarque));
            }
        }
    }
    namespace SuiviEntretienMoto
    {
        class Marque
        {
            public string nomMarque;
            public List<Marque> lesMarques = new List<Marque>() {
                new Marque() { nomMarque = "Beta"},
                new Marque() { nomMarque = "Gas Gas"},
                new Marque() { nomMarque = "Honda"},
                new Marque() { nomMarque = "Husaberg"},
                new Marque() { nomMarque = "Husqvarna"},
                new Marque() { nomMarque = "Kawasaki"},
                new Marque() { nomMarque = "KTM"},
                new Marque() { nomMarque = "Sherco"},
                new Marque() { nomMarque = "Suzuki"},
                new Marque() { nomMarque = "TM"},
                new Marque() { nomMarque = "Yamaha"}
            };
            public Marque() { }
            public Marque(string nomMarque)
            {
                this.nomMarque = nomMarque;
            }
        }
    }
