     protected void EnglishToCzech_Clicked(object sender, EventArgs e)
     {
         if (englishtoczech.BorderColor.Equals(Color.Default))
         {
             englishtoczech.BorderColor = Color.FromHex("#da2c43");
             czechtoenglish.BorderColor = Color.Default;
             english.BorderColor = Color.Default;
         }
         else 
             englishtoczech.BorderColor = Color.Default;  
     }
     protected void CzechToEnglish_Clicked(object sender, EventArgs e)
     {
         if (czechtoenglish.BorderColor.Equals(Color.Default)) 
         {
             czechtoenglish.BorderColor = Color.FromHex("#da2c43");
             englishtoczech.BorderColor = Color.Default; 
             english.BorderColor = Color.Default;
         }
         else
             czechtoenglish.BorderColor = Color.Default;
     }
     protected void English_Clicked(object sender, EventArgs e)
     {
         if (english.BorderColor.Equals(Color.Default))
         {
             english.BorderColor = Color.FromHex("#da2c43");
             englishtoczech.BorderColor = Color.Default; 
             czechtoenglish.BorderColor = Color.Default;
         }
         else
             english.BorderColor = Color.Default;
     }
