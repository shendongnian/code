    public bool CheckPasswordStrength(string password, int x, int y, int z)
    {
       return password.Length >= z &&
              password.Count(c => c.IsUpper(c)) >= x &&
              password.Count(c => c.IsDigit(c)) >= y;
    }
