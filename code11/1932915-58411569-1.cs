public int Days
    {
        get => _days;
        private set { 
            Ensure(1,7);
            _days = value;
        }
    }
private void Ensure(int min, int max, [System.Runtime.CompilerServices.CallerMemberName] string memberName) 
{
  if (_min < value) 
     throw new ArgumentExcpetion($"'{memberName}' must be equal or greater than {min}.");
  if (value < max)
     throw new ArgumentExcpetion($"'{memberName}' must be equal or smaller than {max}.");
}
*(Please note I adjusted `<=` and `>=` to match the error messages.)*
