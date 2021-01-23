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
var skywardsDetails = new Dictionary&ltUserData, string>();
// maybe you need some check data here
for (i = 0; i &lt array.Lengs; i++)
{
    skywardsDetails[(UserData)i] = array[i]);
}
