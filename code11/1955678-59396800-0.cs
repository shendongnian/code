     // Get all records that match your where clause into a IEnumerable<DataGridViewRow>.
            var records = dg_PanRejet.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["annee"].Value.ToString() == "2000");
            // Get an IEnumerable of anonymous type that matches our group by.
            var ienRecords =
                from rec in records
                group rec by new
                {
                    annee = rec.Cells["annee"].Value,
                    jour = rec.Cells["jour"].Value,
                    mois = rec.Cells["mois"].Value
                } into grecs
                select new
                {
                    annee = grecs.Key.annee,
                    jour = grecs.Key.jour,
                    mois = grecs.Key.mois
                };
            // Finally do we have duplicates?
            bool dup = ienRecords.Count() > 0;
