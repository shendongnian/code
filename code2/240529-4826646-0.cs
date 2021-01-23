        //
        // Post: /Admin/IndexGridData
        // Gibt ein JSON Result mit allen Aufträgen für das jqGrid zurück
        [HttpPost]
        public ActionResult IndexGridData(string sidx, string sord, int page, int rows)
        {
            // Ermittlung der Zusatzinformationen die das Grid anzeigt (Anzahl Aufträge, momentan angezeigte Aufträge
            int start = (page - 1) * rows;
           var auftraege = _db.Auftrag
                             .Where(x => x.AuftragStatus != "storno")
                             .OrderBy(x => x.Titel)
                             .Select(auftrag => new AuftragModels.GridAnsicht
                             {
                                 Auftrag_GUID = auftrag.Auftrag_GUID,
                                  Titel = auftrag.Titel,
                                 Bearbeitungsort = auftrag.KT_Bearbeitungsort.Text,
                                 AuftragStatus = auftrag.KT_AuftragStatus.Text,
                             }
                              );
            }
            // zusammen gesetztes SQL Statement speichern
            var sqlstring = ((ObjectQuery)auftraege).ToTraceString();
            // Sortierung des Grids anwenden
            if (sidx == "Titel" && sord == "asc")
            {
                auftraege = auftraege.OrderBy(x => x.Titel);
            }
            else if (sidx == "Titel" && sord == "desc")
            {
                auftraege = auftraege.OrderByDescending(x => x.Titel);
            }
            else if (sidx == "Bearbeitungsort" && sord == "asc")
            {
                auftraege = auftraege.OrderBy(x => x.Bearbeitungsort);
            }
            else if (sidx == "Bearbeitungsort" && sord == "desc")
            {
                auftraege = auftraege.OrderByDescending(x => x.Bearbeitungsort);
            }
            else if (sidx == "AuftragStatus" && sord == "asc")
            {
                auftraege = auftraege.OrderBy(x => x.AuftragStatus);
            }
            else if (sidx == "AuftragStatus" && sord == "desc")
            {
                auftraege = auftraege.OrderByDescending(x => x.AuftragStatus);
            }
            // zusammen gesetztes SQL Statement speichern
            //sqlstring = ((ObjectQuery)auftraege).ToTraceString();
            // aufträge zu einer Liste speichern, damit diese durchlaufen werden kann
            var auftragListe = auftraege
                             .AsEnumerable().ToList();
            // Anzahl der Seiten berechnen
            int summeauftraege = auftragListe.Count();
            int totalPages = (int)Math.Ceiling((float)summeauftraege / (float)rows);
            // nur die Aufträge anzeigen, die auf eienr Seite sichtbar sind
            auftragListe = auftragListe
                             .Skip(start)
                             .Take(rows)
                             .AsEnumerable().ToList();
            // Erstellung des JSON Objekts welches die einzelnen Aufträge enthält
            var jsonauftraege = new object[auftragListe.Count()];
            for (int i = 0; i < auftragListe.Count(); i++)
            {
                jsonauftraege[i] = new
                {
                    id = auftragListe[i].Auftrag_GUID,
                    cell = new[] { 
                    "Details",
                    "Bearbeiten",
                    (auftragListe[i].Titel != null) ? auftragListe[i].Titel.ToString(): "&nbsp;", 
                    (auftragListe[i].Bearbeitungsort != null) ? auftragListe[i].Bearbeitungsort.ToString(): "&nbsp;", 
                    (auftragListe[i].AuftragStatus != null) ? auftragListe[i].AuftragStatus.ToString(): "&nbsp;", 
                }
                };
            }
            // Erstellung des JSON Results welches das Grid versteht
            var result = new JsonResult();
            result.Data = new { page = page, records = summeauftraege, rows = jsonauftraege, total = totalPages };
            return Json(result.Data);
        }
