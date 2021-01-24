        public enum Gender
        {
            Male = 0,
            Female = 1,
            Transgender = 2
        }
        public int HandleGender(string strJsonGender){
            if (strJsonGender == "")
            {
                return -1;
            }
            else {
                // Get int representation of the gender
                return (int)((Gender)Enum
                        .Parse(typeof(Gender),
                               strJsonGender, true));
            }
        }
        public void MainMethod(string strJsonGender) {
            Gender gVal;
            int iVal = HandleGender(strJsonGender);
            if (Enum.IsDefined(typeof(Gender), iVal))
            {
                // Handle if the an actual gender was specified
                gVal = (Gender)iVal;
            }
            else { 
                // Handle "null" logic
            }
