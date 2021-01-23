    public class InstanceInformation {
        public string PatientID { get; set; }
        public string StudyID { get; set; }
        public string SeriesID { get; set; }
        public string InstanceID { get; set; }
        public override string ToString() {
            return String.Format("Series = {0} Study = {1} Patient = {2}", SeriesID, StudyID, PatientID);
        }
    }
    class Program {
        static void Main(string[] args) {
            List<InstanceInformation> infos = new List<InstanceInformation>() {
                new InstanceInformation(){ SeriesID = "A", StudyID = "A1", PatientID = "P1" },
                new InstanceInformation(){ SeriesID = "A", StudyID = "A1", PatientID = "P1" },
                new InstanceInformation(){ SeriesID = "A", StudyID = "A1", PatientID = "P2" },
                new InstanceInformation(){ SeriesID = "A", StudyID = "A2", PatientID = "P1" },
                new InstanceInformation(){ SeriesID = "B", StudyID = "B1", PatientID = "P1"},
                new InstanceInformation(){ SeriesID = "B", StudyID = "B1", PatientID = "P1"},
            };
            IEnumerable<IGrouping<string, InstanceInformation>> bySeries = infos.GroupBy(g => g.SeriesID);
            IEnumerable<IGrouping<string, InstanceInformation>> byStudy = bySeries.SelectMany(g => g.GroupBy(g_inner => g_inner.StudyID));
            IEnumerable<IGrouping<string, InstanceInformation>> byPatient = byStudy.SelectMany(g => g.GroupBy(g_inner => g_inner.PatientID));
            foreach (IGrouping<string, InstanceInformation> group in byPatient) {
                Console.WriteLine(group.Key);
                foreach(InstanceInformation II in group)
                    Console.WriteLine("  " + II.ToString());
            }
    }
