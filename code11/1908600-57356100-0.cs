    var fill = from Projekt in sqlObj.Projekts
                       join s in sqlObj.Status on Projekt.StatusID equals s.Id
                       where Projekt.StatusID !=6
                       select new
                       {
                           Projekt.StatusID,
                           Projekt.ProjektName,
                           Projekt.Projekt_User,
                           s.StatusDescription
                       };
            OnGoingProjekts.ItemsSource = fill.ToList();
