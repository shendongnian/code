    public class Variables {
        public string VariableName1 { get; set; }
        public string VariableName2 { get; set; }
        public string VariableName3 { get; set; }
    }
    public class Model {
        public Model() {
			VariableList1 = new List<Variables>();
			VariableList2 = new List<Variables>();
		}
        public List<Variables> VariableList1 { get; set; }
        public List<Variables> VariableList2 { get; set; }
    }
