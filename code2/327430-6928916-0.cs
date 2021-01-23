         string fullName = "john doe"; // "doe, john"
         string firstName;
         string lastName;
         string[] parts = fullName.Split(new string[] {", "}, StringSplitOptions.None);
         if (parts.Length == 1)
         {
            parts = fullName.Split(' ');
            if (parts.Length == 1)
            {
               lastName = fullName;
               firstName = "";
            }
            else
            {
               lastName = parts[1];
               firstName = parts[0];
            }
         }
         else
         {
            lastName = parts[0];
            firstName = parts[1];
         }
