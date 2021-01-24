public override int GetHashCode()
{
    unchecked
    {
        int hash = 19;
        foreach (var foo in foos)
        {
            hash = hash * 31 + foo.GetHashCode();
        }
        return hash;
    }
}
Primes are generally very useful when hashing. If you're interested to know why, you'll have to look up the maths because people are most likely better at explaining that than I am.
