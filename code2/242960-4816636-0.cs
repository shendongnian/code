    using System.ComponentModel;
    using System;
    [MyCategory("Fred")]
    class Foo {  }
    static class Program
    {
        static void Main()
        {
            var ca = (CategoryAttribute)Attribute.GetCustomAttribute(typeof(Foo), typeof(CategoryAttribute));
            Console.WriteLine(ca.Category);
                  // ^^^ writes "I was Fred, but not I'm EVIL Fred"
        }
    }
    class MyCategoryAttribute : CategoryAttribute
    {
        public MyCategoryAttribute(string category) : base(category) { }
        protected override string GetLocalizedString(string value)
        {
            return "I was " + value + ", but not I'm EVIL " + value;
        }
    }
