enum UserData
{
    Title,
    Firstname,
    Lastname,
    Age,
    Designation,
    Country  
}
//========================================================
string results = "Mr,Mike,Lewis,32,Project Manager,India";
string[] array = results.Split(',');
var skywardsDetails = new Dictionary<UserData, string>();
// maybe you need some check data here
for (int i = 0; i < array.Length; i++)
{
    skywardsDetails[(UserData)i] = array[i];
}
