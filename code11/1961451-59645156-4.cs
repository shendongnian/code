    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication59
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.lesMarques.Items.AddRange(SuiviEntretienMoto.Marque.lesMarques.Select(x => x.nomMarque).ToArray());
            }
        }
    }
    namespace SuiviEntretienMoto
    {
        class Marque
        {
            public string nomMarque;
            public static List<Marque> lesMarques = new List<Marque>() {
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
                //this.nomMarque = nomMarque;
            }
        }
    }
