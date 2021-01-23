    [WebMethod]
            public double ProcitajKursNaDan(DateTime datum, string valuta) {
                List<string> podaci = GetLines("valute.txt");
                double kurs = 0.0;
          
                for (int i = 0; i < podaci.Count; i++) {
                    string[] linija = podaci[i].Split('|');
                  
                    string dat = linija[0];
                    string val = linija[1];
                    string vrednost = linija[2];
             
                    dat = dat.Trim(); 
                    val = val.Trim(); 
                    vrednost = vrednost.Trim();
                   
                    DateTime datIzFajla = DateTime.ParseExact(dat, "d/M/yyyy", null);
                    double kursIzFajla = Convert.ToDouble(vrednost);
                    if (DateTime.Compare(datIzFajla, datum) == 0 && val == valuta)
                        kurs = kursIzFajla;
                }
                return kurs;
            }
            [WebMethod]
            public bool UpisiKursNaDan(DateTime datum, string valuta, double Kurs) {
                string date = datum.ToString("d/M/yyyy");
                string linijaZaUpis = date + " | " + valuta + " | " + Kurs.ToString();
                bool success = false;
                try
                {
                    StreamWriter sw = new StreamWriter(Server.MapPath("podaci/valute.txt"), true);
                    sw.WriteLine(linijaZaUpis);
                    sw.Close();
                    success = true;
                }
                catch {
                    success = false;
                }
                return success;
            }
            [WebMethod]
            public List<string> ProcitajSveValute() {
                List<string> linije = GetLines("valute.txt");
                List<string> ValuteIzFajla = new List<string>();
                for (int i = 0; i < linije.Count; i++) {
                    string linija = linije[i];
                    string valuta = linija.Split('|')[1];
                    valuta = valuta.Trim();
                    ValuteIzFajla.Add(valuta);
                }
                List<string> ValuteKraj = ValuteIzFajla.Distinct().ToList();
                return ValuteKraj;
                 //        try
        //        {
        //            if (!IsPostBack)
        //            {
        //                Service1 servis = new Service1();
        //                List<string> lista = servis.ProcitajSveValute().ToList<string>();
        //                for (int i = 0; i < lista.Count(); i++)
        //                {
        //                    DropDownList1.Items.Add(lista[i]);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write(ex.Message);
        //        }
        //    }
        //    protected void Button1_Click(object sender, EventArgs e)
        //    {
        //        try
        //        {
        //            Service1 servis = new Service1();
        //            DateTime datum = Calendar1.SelectedDate;
        //            string valuta = DropDownList1.SelectedItem.ToString();
        //            double kurs = Convert.ToDouble(TextBox1.Text);
        //            bool nesto = servis.UpisiKursNaDan(datum, valuta, kurs);
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write(ex.Message);
        //        }
        //        TextBox1.Text = " ";
            }
        }
    }
            //    try
            //    {
            //        if (!IsPostBack)
            //        {
            //            Service1 servis = new Service1();
            //            List<string> lista = servis.ProcitajSveValute().ToList<string>();
            //            for (int i = 0; i < lista.Count(); i++)
            //            {
            //                DropDownList1.Items.Add(lista[i]);
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write(ex.Message);
            //    }
            //}
            //protected void Button1_Click(object sender, EventArgs e)
            //{
            //    try
            //    {
            //        Service1 servis = new Service1();
            //        DateTime datum = Calendar1.SelectedDate;
            //        string valuta = DropDownList1.SelectedItem.ToString();
            //        double kurs = servis.ProcitajKursNaDan(datum, valuta);
            //        Label1.Text = kurs.ToString();
            //        if (kurs == 0)
            //        {
            //            Label1.Text = "Ne postoji kursna lista za tu valutu na taj datum!";
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write(ex.Message);
            //    }
            //}
