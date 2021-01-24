public void SetLocation()
{
    var otherClassObj = new otherClassObj(); // Or perhaps some other way of getting the object of the other class.
   
    otherClassObj.CreateEmpList(client); // You may have to change this.
    foreach (var item in otherClassObj.EmpList)
    {
        if (item.Email == "abc@gmail.com")
        {
            item.Location = "US";
        }
    }
}
