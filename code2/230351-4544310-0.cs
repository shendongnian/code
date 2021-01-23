      public static void Main() {
         String strTestDate = "02-11-2007";
         DateTime coverdate = DateTime.ParseExact(strTestDate, "dd-MM-yyyy", null);
         string s = coverdate.ToString(" MMMM yyyy");
         string t = string.Format("{0}{1}",coverdate.Day,extensions[coverdate.Day]);
         string result = t + s;
      }
   }
}
