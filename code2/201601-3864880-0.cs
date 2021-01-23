        public string Description{ get; set;}
        public string Details {get; set;}
    }
    public class MotorPolicy:Policy 
    {
        public void SetReg(string reg)
        {
            base.Details = reg;
        }
    }
    public class HousePolicy:Policy 
    {
        public void SetContents(string contents)
        {
            base.Details = contents;
        }
    }
