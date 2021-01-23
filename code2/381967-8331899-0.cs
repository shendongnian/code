    /// <summary>
    /// Updates client birthdate
    /// </summary>
    /// <param name="clientId">Client identification number</param>
    /// <param name="birthdate">Birth date to update (dd-mm-yyyy)</param>
    /// <returns>nothing</returns>
    public void UpdateBirthdate(Decimal clientId, String birthdate)
    {
         // if you want to parse the date prior to use it
         DateTime dt = DateTime.UtcNow;
         if (DateTime.TryParseExact(birthdate, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
         {
            // continue your method
         }
    }
