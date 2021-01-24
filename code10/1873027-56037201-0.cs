        private void CreateXML(DataTable dataTable)
        {                   
            var list = new List<Row>();
            XmlSerializer writer = new XmlSerializer(typeof(List<Row>));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportZaWeb.xml";
            FileStream file = File.Create(path);
            foreach (DataRow row in dataTable.Rows)
            {
                Row r = new Row();
                r.Naziv = row["Naziv Artikla"].ToString();
                r.JM = row["JM"].ToString();
                r.Kolicina = row["Kolicina"].ToString();
                r.Cena_x0020_vp = row["Cena vp"].ToString();
                r.Cena_x0020_mp = row["Cena mp"].ToString();
                r.Cena_x0020_bod = row["Cena bod"].ToString();
                r.Slika = row["Slika1"].ToString();
                r.Grupa = row["Grupa"].ToString();
                list.Add(r);
            }
            writer.Serialize(file, list);
            file.Close();
        }
