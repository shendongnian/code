public static (int D, int M, decimal S) Parse4ByteHexGeoTag(string hex)
{
   var deg = Convert.ToInt(hex.SubString(0,2));
   var time = Convert.ToDecimal(hex.SubString(3))/60m;
   var min = (int)time;
   var sec = (time%60)*60;
   return (deg, min, sec);
}
Note that you should have an enum indicating if its N or S, W or S, depending on wether `deg` is positive or not.
