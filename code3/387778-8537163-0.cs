    public interface IUser {
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string FullName  { get; set; }
    } 
    
    dynamic New = new ClayFactory();
    existingUser = //grab your existing user here
    IUser clayUser = New.User(){
        FirstName: existingUser.FirstName,
        LastName: existingUser.LastName,
        FullName: existingUser.FirstName + " " + existingUser.LastName;
    
