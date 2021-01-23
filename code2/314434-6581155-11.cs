    class Product
    {
        public string Name { get; set; }
    }
    class Book : Product
    {
        public string BookName { get; set; }
    }
    class RecipeBook : Book
    {
        public int NumRecipes { get; set; }
    }
    class ProgrammingBook : Book
    {
        public string LanguageCovered { get; set; }
    }
    class Disk : Product
    {
        public int Size { get; set; }
    }
