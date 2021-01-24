    public class PostData
    {
        public string DateOfBirth {get; set;}
        public DateTime DateOfBirthDT {get; set;}
    }
    [HttpPost]
    public string MakeAWish([FromBody] PostData data)
    {
        if(DateTime.TryParse(data.DateOfBirth, out DateTime dob)) {
            data.DateOfBirthDT = dob;
            return "success";
        }else {
            return "Please post a valid date";
        }
    }
