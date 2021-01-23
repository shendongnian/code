    static class CollegeRegistration
    {
      //All static member variables
       static int nCollegeId; //College Id will be same for all the students studying
       static string sCollegeName; //Name will be same
       static string sColegeAddress; //Address of the college will also same
    
        //Member functions
       public static int GetCollegeId()
       {
         nCollegeId = 100;
         return (nCollegeID);
       }
        //similarly implementation of others also.
    } //class end
    
    
    public class student
    {
        int nRollNo;
        string sName;
    
        public GetRollNo()
        {
           nRollNo += 1;
           return (nRollNo);
        }
        //similarly ....
        public static void Main()
       {
         //Not required.
         //CollegeRegistration objCollReg= new CollegeRegistration();
    
         //<ClassName>.<MethodName>
         int cid= CollegeRegistration.GetCollegeId();
        string sname= CollegeRegistration.GetCollegeName();
    
    
       } //Main end
    }
