string dateTime = stringRequest.Params["myDate"];
DateTime result = DateTime.MinValue;
if(string.IsNullOrWhiteSpace(dateTime))
{
  dateTime = dateTime.Insert(6, "-").Insert(4, "-");
  DateTime.TryParse(dateTime, out result);
}
bool NoDate = (result == DateTime.MinValue) ? true : false;
