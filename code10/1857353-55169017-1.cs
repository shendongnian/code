`
public CategoryClass{
    string category;
    string subCategory;
    string subSubCategory;
}
`
And then you can put those in a dictionary:
`
static void Main(string[] args)
{
    CategoryClass oldCategory = new CategoryClass();
    CategoryClass newCategory = new CategoryClass();
    Dictionary<CategoryClass, CategoryClass> dict = new Dictionary<CategoryClass, CategoryClass>();
}
`
... or another object.
