    public class InputData{
		public InputData(string serial, int amount){
			this.Serial = serial;
			this.Amount = amount;
		}
		public string Serial {get; set;}
		public int Amount{get;set;}
	}
	
	public class ResultData{
		public ResultData(string serial, int amount, int newAmount, string status){
			this.Serial = serial;
			this.Amount = amount;
			this.NewAmount = newAmount;
			this.Status = status;
		}
		
		public ResultData(string serial, int newAmount, string status){
			this.Serial = serial;
			this.NewAmount = newAmount;
			this.Status = status;
		}
		public string Serial {get; set;}
		public int Amount{get;set;}
		public int NewAmount{get;set;}
		public string Status {get;set;}
	}
