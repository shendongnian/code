            public class IncidentWithDropDown
        {
            public Rpt_IncidentWithConfirm Incident { get; set; }
            public string IncidentTypeText { get; set; }
        }
        public IncidentWithDropDown GetIncident(string IncidentID)
        {
            db = new IncidentsDataContext();
            var incident = (from i in db.Rpt_IncidentWithConfirms
                           join d in db.DropDowns on i.incidentType equals d.value
                           where i.incidentID == Convert.ToInt32(IncidentID)
                           select new IncidentWithDropDown()
                           {
                               Incident = i,
                               IncidentTypeText = d.text
                           }).SingleOrDefault();
            return incident;
        }
