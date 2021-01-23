    public class ListItem : IComparable<ListItem>
    {
    	public int RollNumber { get; set; }
    	public string Name { get; set; }
    	public string AdmissionCode { get; set; }
    	
    	public int CompareTo(ListItem other) {
    		return ExtractNumbers(this.AdmissionCode).CompareTo(ExtractNumbers(other.AdmissionCode));
    	}
    	private int ExtractNumbers(string expr) {
     		return Convert.ToInt32(String.Join(null,System.Text.RegularExpressions.Regex.Split(expr, "[^\\d]")));
    	}
    }
