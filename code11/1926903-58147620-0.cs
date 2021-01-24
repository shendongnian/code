    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    namespace Övning_3___Tipsmaskinen2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Button1_Click(object sender, EventArgs e)
            {
                FileLoader();
            }
            public class Bok
            {
                public string Titel;//Tittle
                public string Författare;//Author
                public string Boktyp;//TBookTYp
                public string ILager;// Bool or InSToridge 
                public Bok(string titel, string författare, string boktyp, string ilager) // method must have a return typ , funkar enbart om jag skriver in void
                {
                    this.Titel = titel;
                    this.Författare = författare;
                    this.Boktyp = boktyp;
                    this.ILager = ilager;
                }
                public override string ToString()
                {
                    return "\t Titel : " + Titel + "\t Skribent : " + Författare + "  \t Boktyp: " + Boktyp + " \t Finns i lager : " + ILager;
                }
            }
            public List<Bok> FileLoader()
            {
                List<Bok> bokList = new List<Bok>();
                if (File.Exists("texter.txt"))
                {
                    StreamReader reader = new StreamReader("texter.txt", Encoding.Default, true);
                    
                    string item = "";
                    while ((item = reader.ReadLine()) != null)
                    {
                        string[] vektor = item.Split(new string[] { "###" }, StringSplitOptions.None);
                        Bok k = new Bok(vektor[0], vektor[1], vektor[2], vektor[3]);
                        bokList.Add(k);
                    }
                    return bokList;
                }
                return null;
            }
        }
    }
 
