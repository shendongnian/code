class ValidAttribute : Attribute
{
    public bool Valid { get; private set; }
    public ValidAttribute(bool valid)
    {
        this.valid = valid;
    }
}
https://stackoverflow.com/questions/2787506/get-enum-from-enum-attribute contains an extension method to read values of attributes. 
