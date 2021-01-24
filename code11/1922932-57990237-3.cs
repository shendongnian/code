public override int GetHashCode()
{
    return age + AsciiValue(name); //i will leave the ascii value implementation to you
}
to your person class and the duplicate persons should no longer exist in the same HashSet
OP's Implementation:
int AsciiCode(string str) { 
    int sum = 0;
    int len = str.Length;
    for(int i = 0; i < len; i++) {
        sum += str[i] * Convert.ToInt32(Math.Pow(2, i));
        sum = sum % (Convert.ToInt32(Math.Pow(2, 31) - 1));
    } 
    return sum;
}
