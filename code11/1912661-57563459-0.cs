cs
var orderArray = new int[]
{
    8106,   // Confirmed Out of Busine
    8105,   // Bankruptcy
    8111,   // Lack of Licensing
    8109,   // Investigations
    8103,   // Government Actions
    8104,   // Pattern of Complaints
    8112,   // Customer Reviews
    8110,   // Accreditation
    8101,   // Misuse of BBB Name
    8107,   // Advisory
    8102,   // Advertising Review
};
Then iterate through array while incrementing order value. While looping check if order array contains actual type id which order value I'm trying to evaluate:
cs
for (int orderValue = 0; orderValue < orderArray.Length; orderValue++)
{
    if (alertTypeId == orderArray[orderValue])
    {
        return orderValue;
    }
}
If not found in the array, return highest value possible:
cs
return int.MaxValue
Whole method would look like this and it would evaluate the order for alert type id:
cs
public int GetAlertTypeIdOrder(short alertTypeId)
{
    var orderArray = new int[]
    {
        8106,   // Confirmed Out of Busine
        8105,   // Bankruptcy
        8111,   // Lack of Licensing
        8109,   // Investigations
        8103,   // Government Actions
        8104,   // Pattern of Complaints
        8112,   // Customer Reviews
        8110,   // Accreditation
        8101,   // Misuse of BBB Name
        8107,   // Advisory
        8102,   // Advertising Review
    };
    for (int orderValue = 0; orderValue < orderArray.Length; orderValue++)
    {
        if (alertTypeId == orderArray[orderValue])
        {
            return orderValue;
        }
    }
    return int.MaxValue;
}
Usage:
cs
var sortedAlerts = alerts
    .AllAlerts
    .OrderByDescending(a => GetAlertTypeIdOrder(a.AlertTypeId))
    .ToList();
It also works in a descending way.
### Solution #2 Order values dictionary
You could achieve better performance by reducing the redundancy - repeated creation of array storing order values. Better idea would be to store the order rules in a dictionary. I know that code below creates an array too, but the concept is that it would be called once to get the dictionary which would be then passed over.
cs
public Dictionary<int, int> GetOrderRules()
{
    var alertTypeIds = new int[]
    {
        8106,   // Confirmed Out of Busine
        8105,   // Bankruptcy
        8111,   // Lack of Licensing
        8109,   // Investigations
        8103,   // Government Actions
        8104,   // Pattern of Complaints
        8112,   // Customer Reviews
        8110,   // Accreditation
        8101,   // Misuse of BBB Name
        8107,   // Advisory
        8102,   // Advertising Review
    };
    var orderRules = new Dictionary<int, int>();
    for (int orderValue = 0; orderValue < alertTypeIds.Length; orderValue++)
    {
        orderRules.Add(alertTypeIds[orderValue], orderValue);
    }
    return orderRules;
}
So the `GetAlertIdOrder()` method would look different, but still keeping the idea from previous solution:
cs
public int GetAlertIdOrder(short alertTypeId, IDictionary<int, int> orderRules)
{
    try
    {
        return orderRules[alertTypeId];
    }
    catch (KeyNotFoundException)
    {
        return int.MaxValue;
    }
}
Usage:
cs
var orderRules = GetOrderRules();
var sortedAlerts = alerts
    .AllAlerts
    .OrderBy(a => GetAlertIdOrder(a.AlertTypeId, orderRules))
    .ToList();
