    /// <summary>
    /// Immutable value type for storing personal numbers
    /// </summary>
    public struct PersonalNumber : IEquatable<PersonalNumber>
    {
        private const string YearHundredOpt = @"(19|20)?"; // 19 or 20 only (optional)
        private const string YearDecade = @"(\d{2})"; // any two digits
        private const string Month = @"(0[1-9]|10|11|12)"; // 01 to 12
        private const string Day = @"(0[1-9]|1\d|2\d|30|31)"; // 01 to 31
        private const string SeparatorAndLastFourOpt = @"([-\+]?)(\d{4})?"; // optional - or + followed by any four digits (optional)
        private const string RegExForValidation =
            "^" + YearHundredOpt + YearDecade + Month + Day + SeparatorAndLastFourOpt + "$";
        private static readonly Regex personNoRegex = new Regex(RegExForValidation, RegexOptions.Compiled);
        private readonly string rawPersonalNumber;
        private readonly string personalNumber;
        private readonly bool isValid;
        private readonly bool isPlus100YearsOld;
        public PersonalNumber(string personalNumber)
        {
            rawPersonalNumber = personalNumber;
            var matches = personNoRegex.Matches(personalNumber);
            var normalizedYYMMDDXXXC = string.Empty;
            isPlus100YearsOld = false;
            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    normalizedYYMMDDXXXC = match.Groups[2].Value + match.Groups[3].Value +
                                  match.Groups[4].Value + match.Groups[6].Value;
                    if (match.Groups[5].Success)
                    {
                        isPlus100YearsOld = match.Groups[5].Value == "+";
                    }
                    break;
                }
            }
            if (normalizedYYMMDDXXXC.Length > 6)
            {
                isValid = personNoRegex.IsMatch(personalNumber) && LuhnAlgorithm.ValidateChecksum(normalizedYYMMDDXXXC);
            }
            else
            {
                isValid = personNoRegex.IsMatch(personalNumber);
            }
            this.personalNumber = string.IsNullOrEmpty(normalizedYYMMDDXXXC) ? rawPersonalNumber : normalizedYYMMDDXXXC;
        }
        public string Number { get { return personalNumber; } }
        public bool IsPlus100YearsOld { get { return isPlus100YearsOld; } }
        public bool IsValid { get { return isValid; } }
        public bool IsMale { get { return !IsFemale; } }
        public bool IsFemale
        {
            get
            {
                var genderCharacter = personalNumber.Substring(personalNumber.Length - 2, 1); // second to last character
                return int.Parse(genderCharacter) % 2 == 0; // even = female, odd = male
            }
        }
        public override string ToString() { return Number; }
        public bool Equals(PersonalNumber other)
        {
            return Equals(other.personalNumber, personalNumber);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof (PersonalNumber)) return false;
            return Equals((PersonalNumber) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int result = (rawPersonalNumber != null ? rawPersonalNumber.GetHashCode() : 0);
                result = (result*397) ^ (personalNumber != null ? personalNumber.GetHashCode() : 0);
                result = (result*397) ^ isValid.GetHashCode();
                return result;
            }
        }
        public static bool operator ==(PersonalNumber left, PersonalNumber right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(PersonalNumber left, PersonalNumber right)
        {
            return !left.Equals(right);
        }
    }
